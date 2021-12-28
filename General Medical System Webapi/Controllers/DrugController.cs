using Entity;
using Entity.DTO;
using Entity.DTO.Join;
using GeneralMedicalBll;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 药品控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDrugInfoBll _drugInfoBll;
        private readonly IManufacturerInfoBll _manufacturerBll;
        private readonly IDrugInfo_ManufacturerInfoBll _drugInfo_Manufacturer;

        public DrugController(IMapper mapper, IDrugInfoBll drugInfoBll,IManufacturerInfoBll manufacturerInfoBll, IDrugInfo_ManufacturerInfoBll drugInfo_Manufacturer)
        {
            _mapper = mapper;
            _drugInfoBll = drugInfoBll;
            _manufacturerBll = manufacturerInfoBll;
            _drugInfo_Manufacturer = drugInfo_Manufacturer;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Drug
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? drugTitle)
        {
            var (drugs, count) = await _drugInfoBll.Query(page, limit, drugTitle);
            //使用Mapster转换成Dto
            var drugDtos = _mapper.Map<List<DrugInfo_ManufacturerInfoJoin>>(drugs);
            if (count != 0) return ApiResultHelp<List<DrugInfo_ManufacturerInfoJoin>>
                    .SuccessResult(drugDtos, count);
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
            var drugs = await _drugInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            //var drugDtos = _mapper.Map<DrugInfoDto>(drugs);
            if (drugs != null) return ApiResultHelp<DrugInfo>.SuccessResult(drugs);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="drugInfo"></param>
        /// <returns></returns>
        /// post api/Drug
        [HttpPost]
        public async Task<ApiResult> Add(DrugInfo drugInfo)
        {
            DrugInfo_ManufacturerInfo dm = new DrugInfo_ManufacturerInfo();

            drugInfo.Createtime = DateTime.Now;

            dm.DrugId = drugInfo.Id;

            dm.ManufacturerId = drugInfo.ManufacturerId;

            dm.Createtime = DateTime.Now;

            if (await _drugInfoBll.AddAsync(drugInfo) && await _drugInfo_Manufacturer.AddAsync(dm)) return ApiResultHelp.SuccessResult();

            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="drugTitle"></param>
        /// <param name="unit"></param>
        /// <param name="stock"></param>
        /// <param name="warningcount"></param>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <param name="manufacturerName"></param>
        /// <returns></returns>
        /// Patch api/Drug/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string drugTitle, string unit, int stock, int warningcount, int type, int price,string manufacturerId)
        {
            var DrugInfo = await _drugInfoBll.FindAsync(id);
            var dm = await _drugInfo_Manufacturer.GetEntities.FirstOrDefaultAsync(x => x.DrugId ==  DrugInfo.Id);
            if (DrugInfo != null && dm != null)
            {
                DrugInfo.DrugTitle = drugTitle;
                DrugInfo.Unit = unit;
                DrugInfo.Stock = stock;
                DrugInfo.Warningcount = warningcount;
                DrugInfo.Type = type;
                DrugInfo.Price = price;
                DrugInfo.ManufacturerId = manufacturerId;

                dm.ManufacturerId = manufacturerId;
        
                if (await _drugInfoBll.UpdateAsync(DrugInfo) && await _drugInfo_Manufacturer.UpdateAsync(dm))
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
                return ApiResultHelp.ErrorResult(404, "没有这个药品");
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

        /// <summary>
        /// 获取下拉选
        /// </summary>
        /// <returns></returns>
        [HttpGet("manufacturerOption")]
        public async Task<List<ManufacturerInfo>> GetSelectOption()
        {
            var option = await _manufacturerBll.GetEntities.Select(d => new ManufacturerInfo
            {
                Id = d.Id,
                ManufacturerName = d.ManufacturerName,
            }).ToListAsync();
            if (option.Count != 0) return option;
            return new List<ManufacturerInfo>();
        }

        /// <summary>
        /// 批量删除(有软删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("Batch")]
        public async Task<ApiResult> BatchDelete(string[] ids)
        {
            bool isSuccess = await _drugInfoBll.UpdateAsync(x => ids.Contains(x.Id), x => new DrugInfo()
            {
                IsDelete = true,
                Deletetime = DateTime.Now,
            });

            if (isSuccess) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "删除失败");
        }
    }
}