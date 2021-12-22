using Entity;
using Entity.DTO;
using Entity.DTO.Join;
using IGeneralMedicalBll;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    /// <summary>
    /// 科室控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentInfoBll _departmentInfoBll;
        private readonly IDoctorInfoBll _doctorInfoBll;

        public DepartmentController(IMapper mapper, IDepartmentInfoBll departmentInfoBll, IDoctorInfoBll doctorInfoBll)
        {
            _mapper = mapper;
            _departmentInfoBll = departmentInfoBll;
            _doctorInfoBll = doctorInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Department
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? departmentName)
        {
            var (departments, count) = await _departmentInfoBll.Query(page, limit, departmentName);
            if (departments.Count != 0) return ApiResultHelp<List<Department_Doctor>>.SuccessResult(departments, count);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Department/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var departments = await _departmentInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            //var departmentDtos = _mapper.Map<DepartmentDto>(departments);
            if (departments != null) return ApiResultHelp<DepartmentInfo>.SuccessResult(departments);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        /// post api/Department
        [HttpPost]
        public async Task<ApiResult> Add(DepartmentInfo departmentInfo)
        {
            departmentInfo.Createtime = DateTime.Now;
            if(await _departmentInfoBll.AnyAsync(x => x.DepartmentName == departmentInfo.DepartmentName))
            {
                return ApiResultHelp.ErrorResult(404, "科室名称重复");
            }

            if (await _departmentInfoBll.AddAsync(departmentInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(404, "添加失败");
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
        /// Patch api/Department/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string departmentName, string leaderId, int count, int status)
        {
            var DepartmentInfo = await _departmentInfoBll.FindAsync(id);
            if (DepartmentInfo != null)
            {
                DepartmentInfo.DepartmentName = departmentName;
                DepartmentInfo.LeaderId = leaderId;
                DepartmentInfo.Count = count;
                DepartmentInfo.Status = status;

                if (await _departmentInfoBll.UpdateAsync(DepartmentInfo))
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
        /// Delete api/Department/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _departmentInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }

        /// <summary>
        /// 获取下拉选
        /// </summary>
        /// <returns></returns>
        [HttpGet("doctorOption")]
        public async Task<List<DoctorInfo>> GetSelectOption()
        {
            var option = await _doctorInfoBll.GetEntities.Select(d => new DoctorInfo
            {
                Id = d.Id,
                DoctorName = d.DoctorName,
            }).ToListAsync();
            if (option.Count != 0) return option;
            return new List<DoctorInfo>();
        }
    }
}