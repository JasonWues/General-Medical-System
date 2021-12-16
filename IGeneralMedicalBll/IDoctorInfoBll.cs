using Entity;

namespace IGeneralMedicalBll
{
    public interface IDoctorInfoBll : IBaseBll<DoctorInfo>
    {
        Task<(List<DoctorInfo> doctorInfos, int count)> Query(int page, int limit, string? doctorName, string? phoneNum);
    }
}