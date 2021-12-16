using Entity;

namespace IGeneralMedicalBll
{
    /// <summary>
    /// 角色业务访问层接口
    /// </summary>
    public interface IRoleInfoBll : IBaseBll<RoleInfo>
    {
        Task<(List<RoleInfo> roleInfos, int count)> Query(int page, int limit, string? roleName);
    }
}