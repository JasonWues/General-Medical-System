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
    public class DrugstorageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDrugstorageBll _drugstorageBll;

        public DrugstorageController(IMapper mapper, IDrugstorageBll drugstorageBll)
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
            var (drugstorages,count) = await _drugstorageBll.Query(page, limit, applicanId);
            //使用Mapster转换成Dto
            var drugstorageDtos = _mapper.Map<List<DrugstorageDto>>(drugstorages);
            if (drugstorageDtos.Count != 0) return ApiResultHelp<List<DrugstorageDto>>.SuccessResult(drugstorageDtos,count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="drugstorage"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> Add(Drugstorage drugstorage)
        {
            if (await _drugstorageBll.AddAsync(drugstorage)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }
    }
}