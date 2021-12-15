using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DiagnosisInfoBll : BaseBll<DiagnosisInfo>, IDiagnosisInfoBll
    {
        public DiagnosisInfoBll(IDiagnosisInfoDal diagnosisInfoDal)
        {
            _iBaseDal = diagnosisInfoDal;
        }
    }
}