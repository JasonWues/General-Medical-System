using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DoctorInfo_RoleInfoBll : BaseBll<DoctorInfo_RoleInfo>, IDoctorInfo_RoleInfoBll
    {
        public DoctorInfo_RoleInfoBll(IDoctorInfo_RoleInfoDal doctorInfo_RoleInfoDal)
        {
            _iBaseDal = doctorInfo_RoleInfoDal;
        }
    }
}