using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class ManufacturerInfoBll : BaseBll<ManufacturerInfo>, IManufacturerInfoBll
    {
        public ManufacturerInfoBll(IManufacturerInfoDal manufacturerInfoDal)
        {
            _iBaseDal = manufacturerInfoDal;
        }

        public async Task<(List<ManufacturerInfo> manufacturerInfos, int count)> Query(int page, int limit, string? manufacturerName, string? contactperson)
        {
            var manufacturerInfo = _iBaseDal.GetEntities;

            int count = await manufacturerInfo.CountAsync();

            if (!string.IsNullOrEmpty(manufacturerName))
            {
                manufacturerInfo = manufacturerInfo.Where(m => m.ManufacturerName.Contains(manufacturerName));
                count = await manufacturerInfo.CountAsync();
            }

            if (!string.IsNullOrEmpty(contactperson))
            {
                manufacturerInfo = manufacturerInfo.Where(m => m.Contactperson.Contains(contactperson));
                count = await manufacturerInfo.CountAsync();
            }

            return (await manufacturerInfo.OrderBy(m => m.Status).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}