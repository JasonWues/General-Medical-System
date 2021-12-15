using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuInfoBll _menuInfoBll;

        public MenuController(IMenuInfoBll menuInfoBll)
        {
            _menuInfoBll = menuInfoBll;
        }

        [HttpGet]
        public Task<JsonResult> Query()
        {

        }
    }
}
