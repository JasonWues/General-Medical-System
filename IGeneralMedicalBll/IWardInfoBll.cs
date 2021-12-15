using Entity;

namespace IGeneralMedicalBll
{
    /// <summary>
    /// 病房业务访问层接口
    /// </summary>
    public interface IWardInfoBll : IBaseBll<WardInfo>
    {
        Task<List<WardInfo>> Query(int page, int limit, string wardTitle, string? type);
    }
}