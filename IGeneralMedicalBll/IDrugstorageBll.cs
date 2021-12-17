using Entity;

namespace IGeneralMedicalBll
{
    public interface IDrugStorageBll : IBaseBll<DrugStorage>
    {
        Task<(List<DrugStorage> drugstorages, int count)> Query(int page, int limit, string? applicanId);

        Task<(bool isAdd, string message)> UpLoad(Stream stream);
    }
}