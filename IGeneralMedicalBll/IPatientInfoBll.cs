using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IPatientInfoBll : IBaseBll<PatientInfo>
    {
        Task<(List<Patient_Ward> patientInfos, int count)> Query(int page, int limit, string? PatientName, string? PhoneNum);
    }
}