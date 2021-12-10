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
    public class RegisterBll:BaseBll<Register>, IRegisterBll
    {
        public RegisterBll(IRegisterDal registerDal)
        {
            _iBaseDal = registerDal;
        }
    }
}
