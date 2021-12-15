using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuInfoBll _menuInfoBll;

        public MenuController(IMenuInfoBll menuInfoBll)
        {
            _menuInfoBll = menuInfoBll;
        }

        [HttpGet("Json")]
        public async Task<List<ParentMenuInfoDto>> GetMenuJson()
        {
            return new List<ParentMenuInfoDto>
            {
                new ParentMenuInfoDto()
                {
                    Title = "工作空间",
                    Type = 0,
                    Href = "",
                    Children = await _menuInfoBll.GetMenuJson()
                }
            };
        }

        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit,string title)
        {
            var menuInfo = await _menuInfoBll.Query(page, limit, title);
            if (menuInfo != null) return ApiResultHelp<List<MenuInfo>>.SuccessResult(menuInfo);
            return ApiResultHelp.ErrorResult(404,"无数据");
        }

        [HttpPost]
        public async Task<ApiResult> Add(MenuInfo menuInfo)
        {
            if(await _menuInfoBll.AddAsync(menuInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405,"删除失败");
        }
    }
}
