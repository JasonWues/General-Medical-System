using IGeneralMedicalBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility.ApiResult;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorInfoBll _doctorInfoBll;
        public DoctorController(IDoctorInfoBll doctorInfoBll)
        {
            _doctorInfoBll = doctorInfoBll;
        }


        [HttpGet("Query")]
        public async Task<ApiResult> QueryAll()
        {
            var list = await _doctorInfoBll.GetEntities.ToListAsync();
            return ApiResultHelp.Success(list);
        }
    }
}
