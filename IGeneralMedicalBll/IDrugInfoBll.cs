using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugInfoBll : IBaseBll<DrugInfo>
    {
        Task<List<DrugInfo>> Query(int page, int limit, string? drugTitle);
    }
}