using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DrugInfoBll : BaseBll<DrugInfo>, IDrugInfoBll
    {
        public DrugInfoBll(IDrugInfoDal drugInfoDal)
        {
            _iBaseDal = drugInfoDal;
        }
    }
}