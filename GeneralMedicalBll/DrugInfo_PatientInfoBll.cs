using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalBll
{
    public class DrugInfo_PatientInfoBll:BaseBll<DrugInfo_PatientInfo>, IDrugInfo_PatientInfoBll
    {
        public DrugInfo_PatientInfoBll(IDrugInfo_PatientInfoDal drugInfo_PatientInfoDal)
        {
            _iBaseDal= drugInfo_PatientInfoDal;
        }
    }
}
