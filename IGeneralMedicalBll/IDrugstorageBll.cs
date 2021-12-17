using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugstorageBll : IBaseBll<DrugStorage>
    {
        Task<(List<DrugStorage> drugstorages, int count)> Query(int page, int limit, string? applicanId);
    }
}