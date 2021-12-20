using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IDepartmentInfoBll : IBaseBll<DepartmentInfo>
    {
        Task<(List<Department_Doctor> departmentInfos, int count)> Query(int page, int limit, string? departmentName);
    }
}