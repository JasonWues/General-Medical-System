using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class BehospitalizedBll : BaseBll<Behospitalized>, IBehospitalizedBll
    {
        public BehospitalizedBll(IBehospitalizedDal behospitalizedDal)
        {
            _iBaseDal = behospitalizedDal;
        }
    }
}