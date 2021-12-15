using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DiagnosisInfo_DrugInfoBll : BaseBll<DiagnosisInfo_DrugInfo>, IDiagnosisInfo_DrugInfoBll
    {
        public DiagnosisInfo_DrugInfoBll(IDiagnosisInfo_DrugInfoDal diagnosisInfo_DrugInfoDal)
        {
            _iBaseDal = diagnosisInfo_DrugInfoDal;
        }
    }
}