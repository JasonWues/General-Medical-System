using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    /// <summary>
    /// 角色业务访问层
    /// </summary>
    public class RoleInfoBll : BaseBll<RoleInfo>, IRoleInfoBll
    {
        public RoleInfoBll(IRoleInfoDal roleInfoDal)
        {
            _iBaseDal = roleInfoDal;
        }

        public async Task<List<RoleInfo>> Query(int page, int limit, string? roleName)
        {
            var roleInfo = _iBaseDal.GetEntities;

            if (!string.IsNullOrEmpty(roleName))
            {
                roleInfo = roleInfo.Where(x => x.RoleName.Contains(roleName));
            }

            return await roleInfo.OrderBy(x => x.Sort).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }
    }
}