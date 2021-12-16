using Entity;

namespace IGeneralMedicalBll
{
    public interface IPatientInfoBll : IBaseBll<PatientInfo>
    {
        Task<(List<PatientInfo> patientInfos, int count)> Query(int page, int limit, string? PatientName);
    }
}