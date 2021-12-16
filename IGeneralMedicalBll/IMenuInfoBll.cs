using Entity;
using Entity.DTO;

namespace IGeneralMedicalBll
{
    public interface IMenuInfoBll : IBaseBll<MenuInfo>
    {
        Task<List<ParentMenuInfoDto>> GetMenuJson();
        Task<(List<MenuInfo> menuInfos, int count)> Query(int page, int limit, string? title);
    }
}
