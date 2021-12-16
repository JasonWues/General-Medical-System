using Entity;

namespace IGeneralMedicalBll
{
    public interface IDepartmentInfoBll : IBaseBll<DepartmentInfo>
    {
        Task<List<DepartmentInfo>> Query(int page, int limit, string? departmentName);
    }
}