using Entity;

namespace IGeneralMedicalBll
{
    public interface IDepartmentInfoBll : IBaseBll<DepartmentInfo>
    {
        Task<(List<DepartmentInfo> departmentInfos, int count)> Query(int page, int limit, string? departmentName);
    }
}