using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 医生表数据访问层接口
    /// </summary>
    public class DoctorInfoDal : BaseDal<DoctorInfo>, IDoctorInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public DoctorInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}