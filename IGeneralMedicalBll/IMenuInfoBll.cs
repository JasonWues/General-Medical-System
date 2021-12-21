using Entity;
using Entity.DTO;

namespace IGeneralMedicalBll
{
    public interface IMenuInfoBll : IBaseBll<MenuInfo>
    {
        Task<List<ParentMenuInfoDto>> GetMenuJson();

        Task<(List<MenuInfoDto> menuInfos, int count)> Query(int page, int limit, string? title);
    }
}