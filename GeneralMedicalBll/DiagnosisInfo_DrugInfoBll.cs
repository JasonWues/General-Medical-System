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
    public class DiagnosisInfo_DrugInfoBll:BaseBll<DiagnosisInfo_DrugInfo>, IDiagnosisInfo_DrugInfoBll
    {
        public DiagnosisInfo_DrugInfoBll(IDiagnosisInfo_DrugInfoDal diagnosisInfo_DrugInfoDal)
        {
            _iBaseDal=diagnosisInfo_DrugInfoDal;
        }
    }
}
