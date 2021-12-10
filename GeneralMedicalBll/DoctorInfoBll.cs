using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DoctorInfoBll : BaseBll<DoctorInfo>, IDoctorInfoBll
    {
        public DoctorInfoBll(IDoctorInfoDal doctorInfoDal)
        {
            _iBaseDal = doctorInfoDal;
        }
    }
}