using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 病房控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class WardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWardInfoBll _wardInfoBll;

        public WardController(IMapper mapper, IWardInfoBll wardInfoBll)
        {
            _mapper = mapper;
            _wardInfoBll = wardInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Ward
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? wardTitle)
        {
            var (wards, count) = await _wardInfoBll.Query(page, limit, wardTitle);
            var wardDtos = _mapper.Map<List<WardInfoDto>>(wards);
            if (wardDtos.Count != 0) return ApiResultHelp<List<WardInfoDto>>.SuccessResult(wardDtos, count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Ward/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var wards = await _wardInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            //var wardDtos = _mapper.Map<WardInfoDto>(wards);
            if (wards != null) return ApiResultHelp<WardInfo>.SuccessResult(wards);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="wardInfo"></param>
        /// <returns></returns>
        /// post api/Ward
        [HttpPost]
        public async Task<ApiResult> Add(WardInfo wardInfo)
        {
            if(await _wardInfoBll.AnyAsync(x => x.WardTitle == wardInfo.WardTitle))
            {
                return ApiResultHelp.ErrorResult(404, "病房重复");
            }
            if (await _wardInfoBll.AddAsync(wardInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wardTitle"></param>
        /// <param name="type"></param>
        /// <param name="num"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// Patch api/Doctor/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string wardTitle, int type, int num, int status)
        {
            var WardInfo = await _wardInfoBll.FindAsync(id);
            if (WardInfo != null)
            {
                WardInfo.WardTitle = wardTitle;
                WardInfo.Type = type;
                WardInfo.Num = num;
                WardInfo.Status = status;

                if (await _wardInfoBll.UpdateAsync(WardInfo))
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
        /// Delete api/Ward/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _wardInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
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
            bool isSuccess = await _wardInfoBll.DeleteAsync(x => ids.Contains(x.Id));
            if (isSuccess) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "删除失败");
        }

    }
}