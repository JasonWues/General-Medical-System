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

        public async Task<List<DepartmentInfo>> Query(int page, int limit, string? departmentName)
        {
            var departmentInfo = _iBaseDal.GetEntities;

            if (!string.IsNullOrEmpty(departmentName))
            {
                departmentInfo = departmentInfo.Where(x => x.DepartmentName.Contains(departmentName));
            }

            return await departmentInfo.OrderBy(d => d.Createtime).Skip((page - 1) * limit).Skip(limit).ToListAsync();
        }
    }
}