using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDrugInfoBll _drugInfoBll;
        public DrugController(IMapper mapper, IDrugInfoBll drugInfoBll)
        {
            _mapper = mapper;
            _drugInfoBll = drugInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Drug
        [HttpGet]
        public async Task<ApiResult> Query()
        {
            var drugs = await _drugInfoBll.GetAll().ToListAsync();
            var drugDtos = _mapper.Map<List<DrugDto>>(drugs);
            if (drugDtos.Count != 0) return ApiResultHelp<List<DrugDto>>.SuccessResult(drugDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Drug/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var drugs = await _drugInfoBll.GetEntities.Where(x => x.Id == id).ToListAsync();
            //使用Mapster转换成Dto
            var drugDtos = _mapper.Map<List<DrugDto>>(drugs);
            if (drugDtos.Count != 0) return ApiResultHelp<List<DrugDto>>.SuccessResult(drugDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="doctorInfo"></param>
        /// <returns></returns>
        /// post api/Drug
        [HttpPost]
        public async Task<ApiResult> Add(DrugInfo drugInfo)
        {
            if (await _drugInfoBll.AddAsync(drugInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentName"></param>
        /// <param name="leaderId"></param>
        /// <param name="count"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// Patch api/Drug/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string drugTitle, string unit, int stock,int warningcount,int type,int price,string manufacturerName)
        {
            var DrugInfo = await _drugInfoBll.FindAsync(id);
            if (DrugInfo != null)
            {
                DrugInfo.DrugTitle = drugTitle;
                DrugInfo.Unit = unit;
                DrugInfo.Stock = stock;
                DrugInfo.Warningcount = warningcount;
                DrugInfo.Type = type;
                DrugInfo.Price = price;
                DrugInfo.ManufacturerName = manufacturerName;

                if (await _drugInfoBll.UpdateAsync(DrugInfo))
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
                return ApiResultHelp.ErrorResult(404, "没有这个科室");
            }
        }

        /// <summary>
        /// 按照id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Delete api/Drug/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _drugInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }
    }
}
