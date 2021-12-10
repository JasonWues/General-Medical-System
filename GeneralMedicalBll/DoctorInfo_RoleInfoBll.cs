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
    public class DoctorInfo_RoleInfoBll:BaseBll<DoctorInfo_RoleInfo>, IDoctorInfo_RoleInfoBll
    {
        public DoctorInfo_RoleInfoBll(IDoctorInfo_RoleInfoDal doctorInfo_RoleInfoDal)
        {
            _iBaseDal= doctorInfo_RoleInfoDal;
        }
    }
}
