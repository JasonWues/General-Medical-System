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

        public async Task<(List<DoctorInfo> doctorInfos,int count)> Query(int page, int limit, string? doctorName, string? phoneNum)
        {
            var doctorInfo = _iBaseDal.GetEntities;

            int count = await doctorInfo.CountAsync();

            if (!string.IsNullOrEmpty(doctorName))
            {
                doctorInfo = doctorInfo.Where(x => x.DoctorName.Contains(doctorName));
                count = await doctorInfo.CountAsync();
            }

            if (!string.IsNullOrEmpty(phoneNum))
            {
                doctorInfo = doctorInfo.Where(x => x.PhoneNum.Contains(phoneNum));
                count = await doctorInfo.CountAsync();
            }

            return (await doctorInfo.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync(),count);
        }
    }
}