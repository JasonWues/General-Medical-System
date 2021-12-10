using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DrugstorageBll : BaseBll<Drugstorage>, IDrugstorageBll
    {
        public DrugstorageBll(IDrugstorageDal drugstorageDal)
        {
            _iBaseDal = drugstorageDal;
        }
    }
}