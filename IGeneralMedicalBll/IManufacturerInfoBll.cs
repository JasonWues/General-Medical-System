using Entity;

namespace IGeneralMedicalBll
{
    public interface IManufacturerInfoBll : IBaseBll<ManufacturerInfo>
    {
        Task<(List<ManufacturerInfo> manufacturerInfos, int count)> Query(int page, int limit, string? manufacturerName, string? contactperson);
    }
}