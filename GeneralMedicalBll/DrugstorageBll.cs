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
    public class DrugstorageBll:BaseBll<Drugstorage>, IDrugstorageBll
    {
        public DrugstorageBll(IDrugstorageDal drugstorageDal)
        {
            _iBaseDal= drugstorageDal;
        }
    }
}
