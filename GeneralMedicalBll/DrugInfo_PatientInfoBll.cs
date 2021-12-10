using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DrugInfo_PatientInfoBll : BaseBll<DrugInfo_PatientInfo>, IDrugInfo_PatientInfoBll
    {
        public DrugInfo_PatientInfoBll(IDrugInfo_PatientInfoDal drugInfo_PatientInfoDal)
        {
            _iBaseDal = drugInfo_PatientInfoDal;
        }
    }
}