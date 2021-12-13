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
    public class DoctorController : ControllerBase
    {
        /// <summary>
        /// 医生控制器
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IDoctorInfoBll _doctorInfoBll;

        public DoctorController(IMapper mapper, IDoctorInfoBll doctorInfoBll)
        {
            _mapper = mapper;
            _doctorInfoBll = doctorInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Doctor
        [HttpGet]
        public async Task<ApiResult> Query()
        {
            var doctors = await _doctorInfoBll.GetAll().ToListAsync();
            //使用Mapster转换成Dto
            var doctorDtos = _mapper.Map<List<DoctorInfoDto>>(doctors);
            if (doctorDtos.Count != 0) return ApiResultHelp<List<DoctorInfoDto>>.SuccessResult(doctorDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Doctor/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var doctors = await _doctorInfoBll.GetEntities.Where(x => x.Id == id).ToListAsync();
            //使用Mapster转换成Dto
            var doctorDtos = _mapper.Map<List<DoctorInfoDto>>(doctors);
            if (doctorDtos.Count != 0) return ApiResultHelp<List<DoctorInfoDto>>.SuccessResult(doctorDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="doctorInfo"></param>
        /// <returns></returns>
        /// post api/Doctor
        [HttpPost]
        public async Task<ApiResult> Add(DoctorInfo doctorInfo)
        {
            if (await _doctorInfoBll.AddAsync(doctorInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按照id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentId"></param>
        /// <param name="status"></param>
        /// <param name="registeredPrice"></param>
        /// <param name="phonenum"></param>
        /// <returns></returns>
        /// Patch api/Doctor/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string? departmentId, int status, decimal registeredPrice, string phonenum)
        {
            var DoctorInfo = await _doctorInfoBll.FindAsync(id);
            if (DoctorInfo != null)
            {
                DoctorInfo.DepartmentId = departmentId;
                DoctorInfo.Status = status;
                DoctorInfo.RegisteredPrice = registeredPrice;
                DoctorInfo.Phonenum = phonenum;

                if (await _doctorInfoBll.UpdateAsync(DoctorInfo))
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

        /// <summary>
        /// 按照id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Delete api/Doctor/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _doctorInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }
    }
}