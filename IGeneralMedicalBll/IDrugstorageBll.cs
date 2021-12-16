using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugstorageBll : IBaseBll<Drugstorage>
    {
        Task<(List<Drugstorage> drugstorages, int count)> Query(int page, int limit, string? applicanId);
    }
}