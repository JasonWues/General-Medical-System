using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DrugInfoBll : BaseBll<DrugInfo>, IDrugInfoBll
    {
        public DrugInfoBll(IDrugInfoDal drugInfoDal)
        {
            _iBaseDal = drugInfoDal;
        }

        public async Task<(List<DrugInfo> drugInfos, int count)> Query(int page, int limit, string? drugTitle)
        {
            var drugInfo = _iBaseDal.GetEntities.Where(x => x.IsDelete == false);

            int count = await drugInfo.CountAsync();

            if (!string.IsNullOrEmpty(drugTitle))
            {
                drugInfo = drugInfo.Where(d => d.DrugTitle.Contains(drugTitle));
                count = await drugInfo.CountAsync();
            }

            return (await drugInfo.OrderBy(x => x.Type).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}