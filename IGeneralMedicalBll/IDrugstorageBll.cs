using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugstorageBll : IBaseBll<Drugstorage>
    {
        Task<List<Drugstorage>> Query(int page, int limit, string applicanId);
    }
}