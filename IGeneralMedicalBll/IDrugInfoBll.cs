using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugInfoBll : IBaseBll<DrugInfo>
    {
        Task<(List<DrugInfo> drugInfos, int count)> Query(int page, int limit, string? drugTitle);
    }
}