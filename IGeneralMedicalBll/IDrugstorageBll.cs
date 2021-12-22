using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IDrugStorageBll : IBaseBll<DrugStorage>
    {
        //Task<(List<DrugStorage> drugstorages, int count)> Query(int page, int limit, string? applicanId);
        Task<(List<DrugStorage_Drug_Manufacturer_Doctor> drugstorages, int count)> Query(int page, int limit, int? type);

        Task<(bool isAdd, string message)> UpLoad(Stream stream, string currentDoctorName);
    }
}