﻿using Entity;
using Entity.DTO;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IDrugInfoBll _drugInfoBll;
        private readonly IManufacturerInfoBll _manufacturerInfoBll;
        public DrugStorageController(IMapper mapper
            , IDrugStorageBll drugstorageBll
            , IDrugInfoBll drugInfoBll
            , IManufacturerInfoBll manufacturerInfoBll
            )
        {
            _mapper = mapper;
            _drugstorageBll = drugstorageBll;
            _drugInfoBll=drugInfoBll;
            _manufacturerInfoBll = manufacturerInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> Qurey(int page, int limit, string? applicanId)
        {
            //var (patients, count) = await _patientInfoBll.Query(page, limit, patientName, phoneNum);
            //if (patients.Count != 0) return ApiResultHelp<List<Patient_Ward>>.SuccessResult(patients, count);
          

            //var (departments, count) = await _departmentInfoBll.Query(page, limit, departmentName);
            //if (departments.Count != 0) return ApiResultHelp<List<Department_Doctor>>.SuccessResult(departments, count);


            var (drugStorages, count) = await _drugstorageBll.Query(page, limit, operatorId);
            //使用Mapster转换成Dto
            var drugstorageDtos = _mapper.Map<List<DrugStorageDto>>(drugStorages);
            if (drugstorageDtos.Count != 0) return ApiResultHelp<List<DrugStorageDto>>.SuccessResult(drugstorageDtos, count);
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
            drugStorage.Createtime = DateTime.Now;
            if (await _drugstorageBll.AddAsync(drugStorage)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        [HttpPost("Upload")]
        public async Task<ApiResult> Upload(IFormFile excelFiles)
        {

            if (excelFiles != null)
            {
                var currentDoctorName = HttpContext.User.Identity.Name;
                

                var stream = excelFiles.OpenReadStream();
                var (isAdd, message) = await _drugstorageBll.UpLoad(stream, currentDoctorName);

                if (isAdd) return ApiResultHelp.SuccessResult(message);
                return ApiResultHelp.ErrorResult(405, message);
            }
            else
            {
                return ApiResultHelp.ErrorResult(400, "无文件");
            }
        }
        /// <summary>
        /// 药品下拉选
        /// </summary>
        /// <returns></returns>
        [HttpGet("DrugOption")]
        public async Task<List<DrugInfo>> ListSelectOption()
        {
            var option = await _drugInfoBll.GetEntities.Select(x => new DrugInfo
            {

                Id = x.Id,
                DrugTitle = x.DrugTitle,
            }).ToListAsync();

            if (option.Count != 0) return option;
            return new List<DrugInfo>();
        }
        /// <summary>
        /// 生产厂家下拉选
        /// </summary>
        /// <returns></returns>
        [HttpGet("ManufacturerOption")]
        public async Task<List<ManufacturerInfo>> ListSelectOption2()
        {
            var option = await _manufacturerInfoBll.GetEntities.Select(x => new ManufacturerInfo
            {
                Id = x.Id,
                ManufacturerName = x.ManufacturerName,
            }).ToListAsync();
            if (option.Count != 0) return option;
            return new List<ManufacturerInfo>();
        }
    }
}