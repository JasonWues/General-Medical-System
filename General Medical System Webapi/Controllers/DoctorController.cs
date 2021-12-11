﻿using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorInfoBll _doctorInfoBll;

        public DoctorController(IMapper mapper,IDoctorInfoBll doctorInfoBll)
        {
            _mapper = mapper;
            _doctorInfoBll = doctorInfoBll;
        }

        [HttpGet]
        public async Task<ApiResult> Query()
        {          
            var doctors = await _doctorInfoBll.GetAll().ToListAsync();
            //使用Mapster转换成Dto
            var doctorDtos = _mapper.Map<List<DoctorInfoDto>>(doctors);
            if (doctorDtos.Count != 0) return ApiResultHelp<List<DoctorInfoDto>>.SuccessResult(doctorDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var list = await _doctorInfoBll.GetEntities.Where(x => x.Id == id).ToListAsync();
            if (list.Count != 0) return ApiResultHelp<List<DoctorInfo>>.SuccessResult(list);
            return ApiResultHelp.ErrorResult(404,"无数据");
        }

        [HttpPost]
        public async Task<ApiResult> Add(DoctorInfo doctorInfo)
        {
            if(await _doctorInfoBll.AddAsync(doctorInfo))return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405,"添加失败");
        }

        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id,string? departmentId,int status, decimal registeredPrice,string phonenum)
        {
            var DoctorInfo = await _doctorInfoBll.FindAsync(id);
            if(DoctorInfo != null)
            {
                DoctorInfo.DepartmentId = departmentId;
                DoctorInfo.Status = status;
                DoctorInfo.RegisteredPrice = registeredPrice;
                DoctorInfo.Phonenum = phonenum;

                if(await _doctorInfoBll.UpdateAsync(DoctorInfo))
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
                return ApiResultHelp.ErrorResult(404, "没有这个医生");
            }
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(string id)
        {
            if(await _doctorInfoBll.DeleteAsync(id))return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }
    }
}