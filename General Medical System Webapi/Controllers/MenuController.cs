using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuInfoBll _menuInfoBll;

        public MenuController(IMenuInfoBll menuInfoBll, IMapper mapper)
        {
            _mapper = mapper;
            _menuInfoBll = menuInfoBll;
        }

        //返回菜单Json数据
        [AllowAnonymous]
        [HttpGet("MenuJson")]
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

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? title)
        {
            var (menuInfo, count) = await _menuInfoBll.Query(page, limit, title);

            if (menuInfo.Count() != 0) return ApiResultHelp<List<MenuInfoDto>>.SuccessResult(menuInfo, count);

            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Doctor/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var menuInfos = await _menuInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            var menuDtos = _mapper.Map<MenuInfoDto>(menuInfos);
            if (menuDtos != null) return ApiResultHelp<MenuInfoDto>.SuccessResult(menuDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> Add(MenuInfo menuInfo)
        {
            if (await _menuInfoBll.AddAsync(menuInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 菜单表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ParentId"></param>
        /// <param name="Title"></param>
        /// <param name="Type"></param>
        /// <param name="Icon"></param>
        /// <param name="Sort"></param>
        /// <param name="Href"></param>
        /// <param name="Opentype"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string ParentId, string Title, int Type, string Icon, int Sort, string Href, string Opentype)
        {
            var menuInfo = await _menuInfoBll.FindAsync(id);
            if (menuInfo != null)
            {
                menuInfo.ParentId = ParentId;
                menuInfo.Title = Title;
                menuInfo.Type = Type;
                menuInfo.Icon = Icon;
                menuInfo.Sort = Sort;
                menuInfo.Href = Href;
                menuInfo.Opentype = Opentype;
                if (await _menuInfoBll.UpdateAsync(menuInfo))
                {
                    return ApiResultHelp.SuccessResult();
                }
                else
                {
                    return ApiResultHelp.ErrorResult(405, "修改失败");
                }
            }
            else
            {
                return ApiResultHelp.ErrorResult(404, "没有这个菜单");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _menuInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }

        /// <summary>
        /// 批量删除(无软删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("Batch")]
        public async Task<ApiResult> BatchDeleteDelete(string[] ids)
        {
            bool isSuccess = await _menuInfoBll.DeleteAsync(x => ids.Contains(x.Id));
            if (isSuccess) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "删除失败");
        }
    }
}