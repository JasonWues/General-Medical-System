using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DoctorInfoBll : BaseBll<DoctorInfo>, IDoctorInfoBll
    {
        private readonly IDepartmentInfoDal _departmentInfoDal;

        public DoctorInfoBll(IDoctorInfoDal doctorInfoDal, IDepartmentInfoDal departmentInfoDal)
        {
            _iBaseDal = doctorInfoDal;
            _departmentInfoDal = departmentInfoDal;
        }

        public async Task<(List<Doctor_Department> doctorInfos, int count)> Query(int page, int limit, string? doctorName, string? phoneNum)
        {
            var doctorInfo = _iBaseDal.GetEntities.Where(x => x.IsDelete == false);

            int count = 0;

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

            var query = from doctor in doctorInfo
                        join department in _departmentInfoDal.GetEntities
                        on doctor.DepartmentId equals department.Id into guoring
                        from result in guoring.DefaultIfEmpty()
                        select new Doctor_Department
                        {
                            Id = doctor.Id,
                            DepartmentId = doctor.DepartmentId,
                            DepartmentName = result.DepartmentName,
                            DoctorName = doctor.DoctorName,
                            PhoneNum = doctor.PhoneNum,
                            RegisteredPrice = (int)doctor.RegisteredPrice,
                            Sex = doctor.Sex == 0 ? "男" : "女",
                            Status = doctor.Status == 0 ? "正常" : "休假",
                            Age = doctor.Age,
                            Createtime = doctor.Createtime.ToString("g")
                        };
            count = query.Count();

            return (await query.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}