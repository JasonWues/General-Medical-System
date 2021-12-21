using Entity;
using Entity.DTO;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 医生控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorInfoBll _doctorInfoBll;
        private readonly IDepartmentInfoBll _departmentInfoBll;
        public DoctorController(IMapper mapper, IDoctorInfoBll doctorInfoBll, IDepartmentInfoBll departmentInfoBll)
        {
            _mapper = mapper;
            _doctorInfoBll = doctorInfoBll;
            _departmentInfoBll = departmentInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Doctor
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? doctorName, string? phoneNum)
        {
            var (doctors, count) = await _doctorInfoBll.Query(page, limit, doctorName, phoneNum);

            if (doctors.Count != 0) return ApiResultHelp<List<Doctor_Department>>.SuccessResult(doctors, count);
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
            var doctors = await _doctorInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            var doctorDtos = _mapper.Map<DoctorInfoDto>(doctors);
            if (doctorDtos != null) return ApiResultHelp<DoctorInfoDto>.SuccessResult(doctorDtos);
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
            doctorInfo.Createtime = DateTime.Now;
            doctorInfo.Password = MD5Helper.MD5Encrypt32(doctorInfo.Password);
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
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        /// Patch api/Doctor/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string? departmentId, int status, decimal registeredPrice, string phoneNum)
        {
            var DoctorInfo = await _doctorInfoBll.FindAsync(id);
            if (DoctorInfo != null)
            {
                DoctorInfo.DepartmentId = departmentId;
                DoctorInfo.Status = status;
                DoctorInfo.RegisteredPrice = registeredPrice;
                DoctorInfo.PhoneNum = phoneNum;

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

        [HttpGet("departmentOption")]
        public async Task<List<DepartmentInfo>> GetSelectOption()
        {
            var option = await _departmentInfoBll.GetEntities.Select(x => new DepartmentInfo
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName,
            }).ToListAsync();

            if (option.Count != 0) return option;
            return new List<DepartmentInfo>();
        }

    }
}