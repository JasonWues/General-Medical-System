using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

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
    }
}