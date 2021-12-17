﻿using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using EFCore.BulkExtensions;

namespace GeneralMedicalBll
{
    public class DrugstorageBll : BaseBll<DrugStorage>, IDrugstorageBll
    {
        private readonly IDrugInfoDal _drugInfoDal;
        private readonly IManufacturerInfoDal _manufacturerInfoDal;
        public DrugstorageBll(IDrugstorageDal drugStorageDal, IDrugInfoDal drugInfoDal, IManufacturerInfoDal manufacturerInfoDal)
        {
            _iBaseDal = drugStorageDal;
            _drugInfoDal = drugInfoDal;
            _manufacturerInfoDal = manufacturerInfoDal;
        }

        public async Task<(List<DrugStorage> drugstorages, int count)> Query(int page, int limit, string? OperatorId)
        {
            var drugstorage = _iBaseDal.GetEntities;

            int count = await drugstorage.CountAsync();

            if (!string.IsNullOrEmpty(OperatorId))
            {
                drugstorage = drugstorage.Where(x => x.OperatorId.Contains(OperatorId));
                count = await drugstorage.CountAsync();
            }

            return (await drugstorage.OrderBy(x => x.DrugId).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }

        public async Task<(bool isAdd, string message)> UpLoad(Stream stream)
        {
            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var drugInfo = _drugInfoDal.GetEntities;

                var manufacturerInfo = _manufacturerInfoDal.GetEntities;

                // 获取Exel指定工作簿
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[1];

                //全部行数
                int rowNum = excelWorksheet.Dimension.Rows;

                //初始化库存数组
                List<DrugStorage> drugStorages = new List<DrugStorage>(rowNum);

                //药品数值修改数组
                List<DrugInfo> drugInfos = new List<DrugInfo>(rowNum);

                string errorMsg = string.Empty;

                for (int row = 2; row <= rowNum; row++)
                {
                    if (excelWorksheet.Cells[row, 1].Value == null || excelWorksheet.Cells[row, 2].Value == null || excelWorksheet.Cells[row, 3].Value == null || excelWorksheet.Cells[row, 4].Value == null)
                    {
                        continue;
                    }

                    //药品名称
                    var drugTitle = excelWorksheet.Cells[row, 1].Value.ToString().Trim();

                    //生产厂家
                    var manufacturerName = excelWorksheet.Cells[row, 2].Value.ToString().Trim();

                    //药品数量
                    int count = (int)excelWorksheet.Cells[row, 3].Value;

                    //还缺少入库人，用当前登入人代替


                    //判断当前是否存在这个药品
                    if (!drugInfo.Any(x => x.DrugTitle == drugTitle))
                    {
                        errorMsg = "请先添加该药品信息";
                        return (false, errorMsg);
                    }

                    //判断当前是否存在这个生产厂家
                    if (!manufacturerInfo.Any(x => x.ManufacturerName == manufacturerName))
                    {
                        errorMsg = string.Format("请先添加该生产厂家信息,位于{0}行",row);
                        return (false, errorMsg);
                    }

                    var drugEntity = await drugInfo.SingleOrDefaultAsync(x => x.DrugTitle == drugTitle);

                    var manufacturerEntity = await manufacturerInfo.SingleOrDefaultAsync(x => x.ManufacturerName == manufacturerName);

                    drugStorages.Add(new DrugStorage
                    {
                        DrugId = drugEntity.Id,
                        ManufacturerId = manufacturerEntity.Id,
                        Count = count,
                        //入库人
                    });

                    drugEntity.Stock += count;

                    drugInfos.Add(drugEntity);

                    await _iBaseDal.GetEntities.
                }

            }
        }
    }
}