using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DrugInfoBll : BaseBll<DrugInfo>, IDrugInfoBll
    {
        private readonly IDrugInfo_ManufacturerInfoDal _drugInfo_ManufacturerInfoDal;
        private readonly IManufacturerInfoDal _manufacturerInfoDal;
        public DrugInfoBll(IDrugInfoDal drugInfoDal
            , IDrugInfo_ManufacturerInfoDal drugInfo_ManufacturerInfoDal
            , IManufacturerInfoDal manufacturerInfoDal
            )
        {
            _iBaseDal = drugInfoDal;
            _drugInfo_ManufacturerInfoDal = drugInfo_ManufacturerInfoDal;
            _manufacturerInfoDal = manufacturerInfoDal;

        }

        public async Task<(List<DrugInfo_ManufacturerInfoJoin> drugInfos, int count)> Query(int page, int limit, string? drugTitle)
        {
            var drugInfo = _iBaseDal.GetEntities;
            int count = 0;


            var query = from d in drugInfo
                        join ddm in _drugInfo_ManufacturerInfoDal.GetEntities
                        on d.Id equals ddm.DrugId into d_drug_manufacturer
                        from dm in d_drug_manufacturer.DefaultIfEmpty()


                        join m in _manufacturerInfoDal.GetEntities
                        on dm.ManufacturerId equals m.Id into m_drug_manufacturer
                        from dmm in m_drug_manufacturer.DefaultIfEmpty()

                        select new DrugInfo_ManufacturerInfoJoin
                        {
                            Id = d.Id,
                            DrugTitle = d.DrugTitle,
                            Unit = d.Unit,
                            Stock = d.Stock,
                            Warningcount = d.Warningcount,
                            Type = d.Type == 0 ? "处方药" : "非处方药",
                            Price = d.Price,
                            Createtime = d.Createtime.ToString("g"),
                            ManufacturerName = dmm.ManufacturerName
                        };
            count = query.Count();
            return (await query.OrderBy(x => x.Type).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}