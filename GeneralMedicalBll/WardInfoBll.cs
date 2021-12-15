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
        public async Task<List<WardInfo>> Query(int page, int limit, string wardTitle, string? type)
        {
            var wardInfo = _iBaseDal.GetEntities;

            if (!string.IsNullOrEmpty(wardTitle))
            {
                wardInfo = wardInfo.Where(x => x.WardTitle.Contains(wardTitle));
            }

            if (!string.IsNullOrEmpty(type))
            {
                wardInfo = wardInfo.Where(x => x.Type.Equals(type));
            }

            return await wardInfo.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }
    }
}