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
    public class DoctorInfoBll:BaseBll<DoctorInfo>, IDoctorInfoBll
    {
        public DoctorInfoBll(IDoctorInfoDal doctorInfoDal)
        {
            _iBaseDal = doctorInfoDal;
        }
    }
}
