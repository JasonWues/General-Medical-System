using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class PatientInfoBll : BaseBll<PatientInfo>, IPatientInfoBll
    {
        public PatientInfoBll(IPatientInfoDal patientInfoDal)
        {
            _iBaseDal = patientInfoDal;
        }
    }
}