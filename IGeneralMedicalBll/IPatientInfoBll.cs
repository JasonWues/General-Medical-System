using Entity;

namespace IGeneralMedicalBll
{
    public interface IPatientInfoBll : IBaseBll<PatientInfo>
    {
        Task<List<PatientInfo>> Query(int page, int limit, string PatientName);
    }
}