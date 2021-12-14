using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleInfoBll _roleInfoBll;

        public RoleController(IMapper mapper, IRoleInfoBll roleInfoBll)
        {
            _mapper = mapper;
            _roleInfoBll = roleInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Role
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit)
        {
            var roles = await _roleInfoBll.GetAll().OrderBy(x=>x.Sort).Skip((page-1)*limit).Take(limit).ToListAsync();
            //使用Mapster转换成Dto
            var roleDtos = _mapper.Map<List<RoleInfoDto>>(roles);
            if (roleDtos.Count != 0) return ApiResultHelp<List<RoleInfoDto>>.SuccessResult(roleDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Role/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id, int page, int limit)
        {
            var roles = await _roleInfoBll.GetEntities.OrderBy(x => x.Sort).Where(x => x.Id == id).Skip((page - 1) * limit).Take(limit).ToListAsync();
            //使用Mapster转换成Dto
            var roleDtos = _mapper.Map<List<RoleInfoDto>>(roles);
            if (roleDtos.Count != 0) return ApiResultHelp<List<RoleInfoDto>>.SuccessResult(roleDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="doctorInfo"></param>
        /// <returns></returns>
        /// post api/Role
        [HttpPost]
        public async Task<ApiResult> Add(RoleInfo roleInfo)
        {
            if (await _roleInfoBll.AddAsync(roleInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentId"></param>
        /// <param name="status"></param>
        /// <param name="registeredPrice"></param>
        /// <param name="phonenum"></param>
        /// <returns></returns>
        /// Patch api/Doctor/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string rolename, string? description, string? authority)
        {
            var RoleInfo = await _roleInfoBll.FindAsync(id);
            if (RoleInfo != null)
            {
                RoleInfo.RoleName = rolename;
                RoleInfo.Description = description;
                RoleInfo.Authority = authority;

                if (await _roleInfoBll.UpdateAsync(RoleInfo))
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
                return ApiResultHelp.ErrorResult(404, "没有这个角色");
            }
        }

        /// <summary>
        /// 按照id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Delete api/Role/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _roleInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }
    }
}