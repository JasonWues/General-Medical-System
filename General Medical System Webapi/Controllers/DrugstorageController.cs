using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstorageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDrugstorageBll _dirugstorageBll;

        public DrugstorageController(IMapper mapper, IDrugstorageBll dirugstorageBll)
        {
            _mapper = mapper;
            _dirugstorageBll = dirugstorageBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Qurey()
        {
            var dirugstorages = await _dirugstorageBll.GetAll().ToListAsync();
            var drugstorageDtos = _mapper.Map<List<DrugstorageDto>>(dirugstorages);
            if (drugstorageDtos.Count != 0) return ApiResultHelp<List<DrugstorageDto>>.SuccessResult(drugstorageDtos);
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
            if (await _dirugstorageBll.AddAsync(drugstorage)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }
    }
}