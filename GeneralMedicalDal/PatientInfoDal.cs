using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 患者表数据访问层接口
    /// </summary>
    public class PatientInfoDal : BaseDal<PatientInfo>, IPatientInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public PatientInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}