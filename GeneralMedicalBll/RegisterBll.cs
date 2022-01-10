using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class RegisterBll : BaseBll<Register>, IRegisterBll
    {
        private readonly IDoctorInfoDal _doctorInfoDal;
        private readonly IPatientInfoDal _patientInfoDal;
        public RegisterBll(IRegisterDal registerDal, IDoctorInfoDal doctorInfoDal, IPatientInfoDal patientInfoDal)
        {
            _iBaseDal = registerDal;
            _doctorInfoDal = doctorInfoDal;
            _patientInfoDal = patientInfoDal;
        }

        public async Task<(List<Register_Doctor_Patient>, int count)> Query(int page, int limit, string? PatientId)
        {
            var register = _iBaseDal.GetEntities;

            int count = 0;

            if (!string.IsNullOrEmpty(PatientId))
            {
                register.Where(x => x.PatientId == PatientId);
                count = register.Count();
            }

            var query = from Register in register
                        join doctor in _doctorInfoDal.GetEntities.Where(x => x.IsDelete == false)
                        on Register.DoctorId equals doctor.Id into Register_doctor
                        from result in Register_doctor.DefaultIfEmpty()

                        join patient in _patientInfoDal.GetEntities.Where(x => x.IsDelete == false)
                        on Register.PatientId equals patient.Id into Register_patient
                        from result2 in Register_patient.DefaultIfEmpty()

                        select new Register_Doctor_Patient
                        {
                            Id = Register.Id,
                            PatientName = result2.PatientName,
                            PatientId = result2.Id,
                            DoctorName = result.DoctorName,
                            Status = Register.Status == 0 ? "未接诊" : "已接诊",
                            Registertime = Register.Registertime.ToString("g"),
                            Paymenttime = Register.Paymenttime.ToString("g"),
                            Treatmenttime = Register.Treatmenttime.ToString("g")
                        };
            count = query.Count();

            return (await query.Skip((page - 1) * limit).Take(limit).ToListAsync(), count);

        }
    }
}