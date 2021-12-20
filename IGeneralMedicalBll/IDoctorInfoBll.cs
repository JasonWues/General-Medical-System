using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IDoctorInfoBll : IBaseBll<DoctorInfo>
    {
        Task<(List<Doctor_Department> doctorInfos, int count)> Query(int page, int limit, string? doctorName, string? phoneNum);
    }
}