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
    public class DrugInfoBll:BaseBll<DrugInfo>, IDrugInfoBll
    {
        public DrugInfoBll(IDrugInfoDal drugInfoDal)
        {
            _iBaseDal= drugInfoDal;
        }

    }
}
