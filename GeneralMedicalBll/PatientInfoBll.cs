using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    /// <summary>
    /// 患者业务访问层
    /// </summary>
    public class PatientInfoBll : BaseBll<PatientInfo>, IPatientInfoBll
    {
        private readonly IWardInfoDal _wardInfoDal;

        public PatientInfoBll(IPatientInfoDal patientInfoDal, IWardInfoDal wardInfoDal)
        {
            _iBaseDal = patientInfoDal;
            _wardInfoDal = wardInfoDal;
        }

        public async Task<(List<Patient_Ward> patientInfos, int count)> Query(int page, int limit, string? patientName, string? phoneNum)
        {
            var patientInfo = _iBaseDal.GetEntities;

            int count = 0;

            if (!string.IsNullOrEmpty(patientName))
            {
                patientInfo = patientInfo.Where(x => x.PatientName.Contains(patientName));
                count = await patientInfo.CountAsync();
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                patientInfo = patientInfo.Where(x => x.PhoneNum.Contains(phoneNum));
                count = await patientInfo.CountAsync();
            }

            var query = from patient in patientInfo
                        join ward in _wardInfoDal.GetEntities
                        on patient.WardId equals ward.Id into guoring
                        from result in guoring.DefaultIfEmpty()
                        select new Patient_Ward
                        {
                            Id = patient.Id,
                            WardId = patient.WardId,
                            WardTitle = result.WardTitle,
                            PatientName = patient.PatientName,
                            Age = patient.Age,
                            Sex = patient.Sex == 0 ? "男" : "女",
                            PhoneNum = patient.PhoneNum,
                            Status = patient.Status == 0 ? "住院" : "出院",
                            Createtime = patient.Createtime.ToString("g")
                        };
            count = query.Count();

            return (await query.OrderBy(x => x.Status).Skip((page - 1) * limit).Take(limit).ToListAsync(), count);
        }
    }
}