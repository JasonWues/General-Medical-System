using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    /// <summary>
    /// 病房业务访问层
    /// </summary>
    public class WardInfoBll : BaseBll<WardInfo>, IWardInfoBll
    {
        public WardInfoBll(IWardInfoDal wardInfoDal)
        {
            _iBaseDal = wardInfoDal;
        }
        public async Task<(List<WardInfo>,int count)> Query(int page, int limit, string? wardTitle)
        {
            var wardInfo = _iBaseDal.GetEntities;

            int count = await wardInfo.CountAsync();

            if (!string.IsNullOrEmpty(wardTitle))
            {
                wardInfo = wardInfo.Where(x => x.WardTitle.Contains(wardTitle));
                count = await wardInfo.CountAsync();
            }

            return (await wardInfo.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}