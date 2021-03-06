using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 制造商控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManufacturerInfoBll _manufacturerInfoBll;

        public ManufacturerController(IMapper mapper, IManufacturerInfoBll manufacturerInfoBll)
        {
            _mapper = mapper;
            _manufacturerInfoBll = manufacturerInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/manufacturerInfo
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? ManufacturerName, string? Contactperson)
        {
            var (manufacturerInfos, count) = await _manufacturerInfoBll.Query(page, limit, ManufacturerName, Contactperson);
            //使用Mapster转换成Dto
            var ManufacturerInfoDtos = _mapper.Map<List<ManufacturerInfoDto>>(manufacturerInfos);
            if (ManufacturerInfoDtos.Count != 0) return ApiResultHelp<List<ManufacturerInfoDto>>.SuccessResult(ManufacturerInfoDtos, count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///  Get api/manufacturerInfo/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var manufacturerInfos = await _manufacturerInfoBll.FindAsync(id);

            if (manufacturerInfos != null) return ApiResultHelp<ManufacturerInfo>.SuccessResult(manufacturerInfos);

            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="manufacturerInfo"></param>
        /// <returns></returns>
        ///  Get api/manufacturerInfo
        [HttpPost]
        public async Task<ApiResult> Add(ManufacturerInfo manufacturerInfo)
        {
            if (await _manufacturerInfoBll.AddAsync(manufacturerInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ManufacturerName"></param>
        /// <param name="Contactperson"></param>
        /// <param name="Phonenum"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string ManufacturerName, string Contactperson, string Phonenum, int Status)
        {
            var manufacturerInfo = await _manufacturerInfoBll.FindAsync(id);
            if (manufacturerInfo != null)
            {
                manufacturerInfo.ManufacturerName = ManufacturerName;
                manufacturerInfo.Contactperson = Contactperson;
                manufacturerInfo.Phonenum = Phonenum;
                manufacturerInfo.Status = Status;
                if (await _manufacturerInfoBll.UpdateAsync(manufacturerInfo))
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
                return ApiResultHelp.ErrorResult(404, "没有这个厂家");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _manufacturerInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
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
            bool isSuccess = await _manufacturerInfoBll.DeleteAsync(x => ids.Contains(x.Id));
            if (isSuccess) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "删除失败");
        }
    }
}