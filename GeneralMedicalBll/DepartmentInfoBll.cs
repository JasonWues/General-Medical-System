using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DepartmentInfoBll : BaseBll<DepartmentInfo>, IDepartmentInfoBll
    {
        private readonly IDoctorInfoDal _doctorInfoDal;

        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal, IDoctorInfoDal doctorInfoDal)
        {
            _iBaseDal = departmentInfoDal;
            _doctorInfoDal = doctorInfoDal;
        }

        public async Task<(List<Department_Doctor> departmentInfos, int count)> Query(int page, int limit, string? departmentName)
        {
            var departmentInfo = _iBaseDal.GetEntities;
            int count = 0;

            if (!string.IsNullOrEmpty(departmentName))
            {
                departmentInfo = departmentInfo.Where(x => x.DepartmentName.Contains(departmentName));
                count = departmentInfo.Count();
            }

            var query = from department in departmentInfo
                        join doctor in _doctorInfoDal.GetEntities
                        on department.LeaderId equals doctor.Id into guoring
                        from result in guoring.DefaultIfEmpty()
                        select new Department_Doctor
                        {
                            Id = department.Id,
                            LeaderId = department.Id,
                            LeaderName = result.DoctorName,
                            DepartmentName = department.DepartmentName,
                            Status = department.Status == 0 ? "开启" : "关闭",
                            Count = department.Count,
                            Createtime = department.Createtime.ToString("g")
                        };

            count = query.Count();

            return (await query.OrderBy(d => d.Count).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}