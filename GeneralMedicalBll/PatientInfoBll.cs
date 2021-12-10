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
    public class PatientInfoBll:BaseBll<PatientInfo>, IPatientInfoBll
    {
        public PatientInfoBll(IPatientInfoDal patientInfoDal)
        {
            _iBaseDal= patientInfoDal;
        }
    }
}
