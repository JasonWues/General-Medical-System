using Entity;

namespace IGeneralMedicalBll
{
    public interface IManufacturerInfoBll : IBaseBll<ManufacturerInfo>
    {
        Task<List<ManufacturerInfo>> Query(int page, int limit, string? manufacturerName, string? contactperson);
    }
}