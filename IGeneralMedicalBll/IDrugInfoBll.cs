using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IDrugInfoBll : IBaseBll<DrugInfo>
    {
        Task<(List<DrugInfo_ManufacturerInfoJoin> drugInfos, int count)> Query(int page, int limit, string? drugTitle);
    }
}