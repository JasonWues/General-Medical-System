using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class PatientInfoBll : BaseBll<PatientInfo>, IPatientInfoBll
    {
        public PatientInfoBll(IPatientInfoDal patientInfoDal)
        {
            _iBaseDal = patientInfoDal;
        }

        public async Task<List<PatientInfo>> Query(int page, int limit, string PatientName)
        {
            var patientInfo = _iBaseDal.GetEntities;

            if (!string.IsNullOrEmpty(PatientName))
            {
                patientInfo = patientInfo.Where(x => x.Status.Contains(PatientName));
            }

            return await patientInfo.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }
    }
}