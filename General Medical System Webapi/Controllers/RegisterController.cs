using Entity;
using Entity.DTO.Join;
using Entity.DTO.ViewModels;
using IGeneralMedicalBll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterBll _registerBll;
        private readonly IPatientInfoBll _patientInfoBll;
        private readonly IDoctorInfoBll _doctorInfoBll;
        private readonly IDiagnosisInfo_DrugInfoBll _diagnosisInfoBll;
        private readonly IDiagnosisInfoBll _diagnosisBll;
        private readonly IDrugInfoBll _drugInfoBll;
        public RegisterController(IRegisterBll registerBll, IPatientInfoBll patientInfoBll, IDoctorInfoBll doctorInfoBll, IDiagnosisInfo_DrugInfoBll diagnosisInfo_DrugInfoBll, IDiagnosisInfoBll diagnosisInfoBll, IDrugInfoBll drugInfoBll)
        {
            _registerBll = registerBll;
            _patientInfoBll = patientInfoBll;
            _doctorInfoBll = doctorInfoBll;
            _diagnosisInfoBll = diagnosisInfo_DrugInfoBll;
            _diagnosisBll = diagnosisInfoBll;
            _drugInfoBll = drugInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? name)
        {
            var (register, count) = await _registerBll.Query(page, limit, name);
            if (count != 0) return ApiResultHelp<List<Register_Doctor_Patient>>.SuccessResult(register, count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> Add(Register register)
        {
            register.Registertime = DateTime.Now;
            register.Paymenttime = DateTime.Now.AddSeconds(30);
            register.Status = 0;
            if (await _registerBll.AddAsync(register)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "添加失败");
        }

        [HttpGet("patientOption")]
        public async Task<List<PatientInfo>> GetSelectOption()
        {
            var option = await _patientInfoBll.GetEntities.Select(x => new PatientInfo()
            {
                Id = x.Id,
                PatientName = x.PatientName
            }).ToListAsync();

            if (option.Count != 0) return option;
            return new List<PatientInfo>(0);
        }

        [HttpPost("Diagnosis/{patientId}")]
        public async Task<ApiResult> Diagnosis(string patientId, DrugDiagnosis[] drugDiagnoses)
        {
            List<DiagnosisInfo_DrugInfo> diagnosis_drug = new List<DiagnosisInfo_DrugInfo>();
            List<DiagnosisInfo> diagnosisList = new List<DiagnosisInfo>(drugDiagnoses.Length);

            var register = await _registerBll.GetEntities.FirstAsync(x => x.PatientId == patientId && x.Status == 0);
            if (register != null)
            {
                register.Status = 1;
            };

            if (drugDiagnoses.Length != 0)
            {
                foreach (var drugdiagnosis in drugDiagnoses)
                {
                    //添加诊断
                    var diagnosisEntity = new DiagnosisInfo()
                    {
                        PatientId = patientId,
                        //查询当前登入医生
                        DoctorId = await _doctorInfoBll.GetEntities.Where(x => x.DoctorName == HttpContext.User.Identity.Name).Select(x => x.Id).FirstAsync(),
                        Opinion = drugdiagnosis.Opinion,
                        Createtime = DateTime.Now,
                    };

                    diagnosisList.Add(diagnosisEntity);
                    //查询药品库存
                    var drugInfo = await _drugInfoBll.FindAsync(drugdiagnosis.Id);
                    //比较库存
                    if (drugInfo.Stock > drugdiagnosis.num)
                    {


                        diagnosis_drug.Add(new DiagnosisInfo_DrugInfo()
                        {
                            DrugId = drugdiagnosis.Id,
                            DiagnosisId = diagnosisEntity.Id,
                            Createtime = DateTime.Now
                        });

                    }
                    else
                    {
                        return ApiResultHelp.ErrorResult(404, "药品不足");
                    }
                }
            }
            else
            {
                return ApiResultHelp.ErrorResult(404, "当前未选择药品");
            }

            //添加诊断
            await _diagnosisBll.AddAsync(diagnosisList);
            //添加诊断药品关联
            await _diagnosisInfoBll.AddAsync(diagnosis_drug);

            await _registerBll.UpdateAsync(register);

            return ApiResultHelp.SuccessResult();

        }
    }
}
