using Entity;
using Entity.DTO.Join;
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
        public RegisterController(IRegisterBll registerBll, IPatientInfoBll patientInfoBll)
        {
            _registerBll = registerBll;
            _patientInfoBll = patientInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Query(int page,int limit,string? name)
        {
            var (register,count) = await _registerBll.Query(page, limit, name);
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
    }
}
