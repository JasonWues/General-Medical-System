using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IDoctorInfo_RoleInfoBll _doctorInfo_RoleInfoBll;
        private readonly IDoctorInfoBll _doctorInfoBll;

        public RoleController(
            IMapper mapper,
            IRoleInfoBll roleInfoBll,
            IDoctorInfo_RoleInfoBll doctorInfo_RoleInfoBll,
            IDoctorInfoBll doctorInfoBll)
        {
            _mapper = mapper;
            _roleInfoBll = roleInfoBll;
            _doctorInfo_RoleInfoBll = doctorInfo_RoleInfoBll;
            _doctorInfoBll = doctorInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Role
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? roleName)
        {
            var (roles, count) = await _roleInfoBll.Query(page, limit, roleName);
            //使用Mapster转换成Dto
            var roleDtos = _mapper.Map<List<RoleInfoDto>>(roles);
            if (roleDtos.Count != 0) return ApiResultHelp<List<RoleInfoDto>>.SuccessResult(roleDtos, count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Role/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var roles = await _roleInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            var roleDtos = _mapper.Map<RoleInfoDto>(roles);
            if (roleDtos != null) return ApiResultHelp<RoleInfoDto>.SuccessResult(roleDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        /// post api/Role
        [HttpPost]
        public async Task<ApiResult> Add(RoleInfo roleInfo)
        {
            roleInfo.Createtime = DateTime.Now;
            if (await _roleInfoBll.AddAsync(roleInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rolename"></param>
        /// <param name="description"></param>
        /// <param name="authority"></param>
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

        /// <summary>
        /// 批量删除(有软删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("Batch")]
        public async Task<ApiResult> BatchDelete(string[] ids)
        {
            bool isSuccess = await _roleInfoBll.UpdateAsync(x => ids.Contains(x.Id), x => new RoleInfo()
            {
                IsDelete = true,
                Deletetime = DateTime.Now,
            });

            if (isSuccess) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "删除失败");
        }

        /// <summary>
        /// 获取用户备选数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("{roleId}")]
        public async Task<ApiResult> GetBindUserInfo(string roleInfoId)
        {
            //查询用户信息下拉选数据
            var doctorInfoOptions = _doctorInfoBll.GetEntities.Where(d=> d.IsDelete==false).Select(x => new DoctorInfo
            {
                Id = x.Id,
                DoctorName = x.DoctorName
            });
            //获取当前角色已绑定的用户id集合
            var doctorInfoIds = _doctorInfo_RoleInfoBll.GetEntities.Where(d=>d.RoleId == roleInfoId).Select(x=> new DoctorInfo_RoleInfo
            {
                DoctorId = x.DoctorId
            });

            var option = new
            {
                doctorInfoOptions,
                doctorInfoIds
            };

            if (option != null) return ApiResultHelp.SuccessResult(option);
            return ApiResultHelp.ErrorResult(404, "未查询到对应数据");
        }



        ////测试代码

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="doctor_Roleinfo"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ApiResult> Bindrole(DoctorInfo_RoleInfo doctor_Roleinfo)
        {
            doctor_Roleinfo.Createtime = DateTime.Now;

            if (await _doctorInfo_RoleInfoBll.AddAsync(doctor_Roleinfo)) return ApiResultHelp.SuccessResult();

            return ApiResultHelp.ErrorResult(404, "绑定失败");
        }
    }
}