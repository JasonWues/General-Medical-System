using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DoctorInfoBll : BaseBll<DoctorInfo>, IDoctorInfoBll
    {
        public DoctorInfoBll(IDoctorInfoDal doctorInfoDal)
        {
            _iBaseDal = doctorInfoDal;
        }

        public async Task<List<DoctorInfo>> Query(int page, int limit, string? doctorName, string? phoneNum)
        {
            var doctorInfo = _iBaseDal.GetEntities;

            if (!string.IsNullOrEmpty(doctorName))
            {
                doctorInfo = doctorInfo.Where(x => x.DoctorName.Contains(doctorName));
            }

            if (!string.IsNullOrEmpty(phoneNum))
            {
                doctorInfo = doctorInfo.Where(x => x.PhoneNum.Contains(phoneNum));
            }

            return await doctorInfo.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }
    }
}