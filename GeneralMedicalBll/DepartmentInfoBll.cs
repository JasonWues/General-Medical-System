using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DepartmentInfoBll : BaseBll<DepartmentInfo>, IDepartmentInfoBll
    {
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal)
        {
            _iBaseDal = departmentInfoDal;
        }

        public async Task<(List<DepartmentInfo> departmentInfos,int count)> Query(int page, int limit, string? departmentName)
        {
            var departmentInfo = _iBaseDal.GetEntities;

            int count = await departmentInfo.CountAsync();

            if (!string.IsNullOrEmpty(departmentName))
            {
                departmentInfo = departmentInfo.Where(x => x.DepartmentName.Contains(departmentName));
                count = departmentInfo.Count();
            }

            return (await departmentInfo.OrderBy(d => d.Createtime).Skip((page - 1) * limit).Take(limit).ToListAsync(),count);
        }
    }
}