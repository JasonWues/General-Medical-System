using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 医生角色关联表数据访问层接口
    /// </summary>
    public class DoctorInfo_RoleinfoDal : BaseDal<DoctorInfo_RoleInfo>, IDoctorInfo_RoleInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public DoctorInfo_RoleinfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}