using Entity;
using Entity.DTO;

namespace IGeneralMedicalBll
{
    public interface IMenuInfoBll : IBaseBll<MenuInfo>
    {
        Task<List<ParentMenuInfoDto>> GetMenuJson();
        Task<List<MenuInfo>> Query(int page, int limit, string title);
    }
}
