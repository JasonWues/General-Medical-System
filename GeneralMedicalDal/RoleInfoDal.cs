using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 角色表数据访问层接口
    /// </summary>
    public class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public RoleInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}