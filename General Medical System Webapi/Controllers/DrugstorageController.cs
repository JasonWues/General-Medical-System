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
    /// 药品仓库控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DrugStorageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDrugStorageBll _drugstorageBll;

        public DrugStorageController(IMapper mapper, IDrugStorageBll drugstorageBll)
        {
            _mapper = mapper;
            _drugstorageBll = drugstorageBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Qurey(int page,int limit,string? applicanId)
        {
            var (drugStorages, count) = await _drugstorageBll.Query(page, limit, applicanId);
            //使用Mapster转换成Dto
            var drugstorageDtos = _mapper.Map<List<DrugStorageDto>>(drugStorages);
            if (drugstorageDtos.Count != 0) return ApiResultHelp<List<DrugStorageDto>>.SuccessResult(drugstorageDtos,count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="drugStorage"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> Add(DrugStorage drugStorage)
        {
            if (await _drugstorageBll.AddAsync(drugStorage)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        [HttpPost("Upload")]
        public async Task<ApiResult> Upload(IFormFile excelFiles)
        {
            if(excelFiles != null)
            {
                var stream = excelFiles.OpenReadStream();
                var (isAdd,message) = await _drugstorageBll.UpLoad(stream);

                if (isAdd)return ApiResultHelp.SuccessResult(message);
                return ApiResultHelp.ErrorResult(405,message);
            }
            else
            {
                return ApiResultHelp.ErrorResult(400,"无文件");
            }
        }
    }
}