using Entity;

namespace IGeneralMedicalBll
{
    public interface IDoctorInfoBll : IBaseBll<DoctorInfo>
    {
        Task<List<DoctorInfo>> Query(int page, int limit, string? doctorName, string? phoneNum);
    }
}