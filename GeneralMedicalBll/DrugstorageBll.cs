using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace GeneralMedicalBll
{
    public class DrugStorageBll : BaseBll<DrugStorage>, IDrugStorageBll
    {
        private readonly IDrugInfoDal _drugInfoDal;
        private readonly IDoctorInfoDal _doctorInfoDal;
        private readonly IManufacturerInfoDal _manufacturerInfoDal;


        public DrugStorageBll(IDrugStorageDal drugStorageDal, IDrugInfoDal drugInfoDal, IManufacturerInfoDal manufacturerInfoDal, IDoctorInfoDal doctorInfoDal)
        {
            _iBaseDal = drugStorageDal;
            _drugInfoDal = drugInfoDal;
            _manufacturerInfoDal = manufacturerInfoDal;
            _doctorInfoDal = doctorInfoDal;
        }


        public async Task<(List<DrugStorage_Drug_Manufacturer_Doctor> drugstorages, int count)> Query(int page, int limit, int? type)
        {
            var drugStorage = _iBaseDal.GetEntities;

            int count = 0;

            if (type != null)
            {
                drugStorage = drugStorage.Where(d => d.Type == type);
                count = drugStorage.Count();
            }

            var query = from drugstorage in drugStorage
                        join dr in _drugInfoDal.GetEntities
                        on drugstorage.DrugId equals dr.Id into drugstorage_drug
                        from drugStordr in drugstorage_drug.DefaultIfEmpty()

                        join manufacturer in _manufacturerInfoDal.GetEntities
                        on drugstorage.ManufacturerId equals manufacturer.Id into drugstorage_manufacturer
                        from result in drugstorage_manufacturer.DefaultIfEmpty()

                        join doctor in _doctorInfoDal.GetEntities
                        on drugstorage.OperatorId equals doctor.Id into drugstorage_doctor
                        from doctorOperator in drugstorage_doctor.DefaultIfEmpty()

                        join doctorOut in _doctorInfoDal.GetEntities
                        on drugstorage.OutgoerId equals doctorOut.Id into drugstorage_doctorOut
                        from doctorOut in drugstorage_doctorOut.DefaultIfEmpty()

                        select new DrugStorage_Drug_Manufacturer_Doctor
                        {
                            Id = drugstorage.Id,
                            Count = drugstorage.Count,
                            ManufacturerName = result.ManufacturerName,
                            DrugTitle = drugStordr.DrugTitle,
                            OutgoerDoctorName = doctorOut.DoctorName,
                            OperatorDoctorName = doctorOperator.DoctorName,
                            Type = drugstorage.Type == 0 ? "出库" : "入库",
                            Createtime = drugstorage.Createtime.ToString("g")
                        };

            count = query.Count();
            return (await query.OrderBy(x => x.Count).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);

        }

        public async Task<(bool isAdd, string message)> UpLoad(Stream stream, string currentDoctorName)
        {
            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var drugInfo = _drugInfoDal.GetTrackEntities;

                var manufacturerInfo = _manufacturerInfoDal.GetTrackEntities;

                // 获取Exel指定工作簿
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];

                if (excelWorksheet.Dimension == null)
                {
                    return (false, "Excel文件为空");
                }
                //全部行数
                int rowNum = excelWorksheet.Dimension.Rows;

                //初始化库存数组
                List<DrugStorage> drugStorages = new List<DrugStorage>(rowNum);

                //药品数值修改数组
                List<DrugInfo> drugInfos = new List<DrugInfo>(rowNum);

                string errorMsg = string.Empty;

                for (int row = 2; row <= rowNum; row++)
                {
                    if (excelWorksheet.Cells[row, 1].Value == null || excelWorksheet.Cells[row, 2].Value == null || excelWorksheet.Cells[row, 3].Value == null)
                    {
                        continue;
                    }

                    //药品名称
                    var drugTitle = excelWorksheet.Cells[row, 1].Value.ToString().Trim();

                    //生产厂家
                    var manufacturerName = excelWorksheet.Cells[row, 2].Value.ToString().Trim();

                    //药品数量
                    int count = int.Parse(excelWorksheet.Cells[row, 3].Value.ToString());



                    //判断当前是否存在这个药品
                    if (!drugInfo.Any(x => x.DrugTitle == drugTitle))
                    {
                        errorMsg = string.Format("请先添加该药品信息,位于第{0}行", row);
                        return (false, errorMsg);
                    }

                    //判断当前是否存在这个生产厂家
                    if (!manufacturerInfo.Any(x => x.ManufacturerName == manufacturerName))
                    {
                        errorMsg = string.Format("请先添加该生产厂家信息,位于第{0}行", row);
                        return (false, errorMsg);
                    }

                    var doctorEntity = await _doctorInfoDal.GetEntities.FirstAsync(x => x.DoctorName == currentDoctorName);

                    var drugEntity = await drugInfo.SingleOrDefaultAsync(x => x.DrugTitle == drugTitle);

                    var manufacturerEntity = await manufacturerInfo.SingleOrDefaultAsync(x => x.ManufacturerName == manufacturerName);

                    drugStorages.Add(new DrugStorage
                    {
                        DrugId = drugEntity.Id,
                        ManufacturerId = manufacturerEntity.Id,
                        Count = count,
                        OperatorId = doctorEntity.Id
                    });

                    drugEntity.Stock += count;

                    drugInfos.Add(drugEntity);
                }

                await _iBaseDal.AddAsync(drugStorages);

                await _drugInfoDal.UpdateAsync(drugInfos);
            }

            return (true, "成功");
        }
    }
}