using Entity;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterBll _registerBll;
        public RegisterController(IRegisterBll registerBll)
        {
            _registerBll = registerBll;
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
    }
}
