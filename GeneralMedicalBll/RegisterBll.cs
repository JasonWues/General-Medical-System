using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class RegisterBll : BaseBll<Register>, IRegisterBll
    {
        public RegisterBll(IRegisterDal registerDal)
        {
            _iBaseDal = registerDal;
        }
    }
}