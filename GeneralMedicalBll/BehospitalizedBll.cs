using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class BehospitalizedBll : BaseBll<BehospitalizedInfo>, IBehospitalizedBll
    {
        public BehospitalizedBll(IBehospitalizedDal behospitalizedDal)
        {
            _iBaseDal = behospitalizedDal;
        }
    }
}