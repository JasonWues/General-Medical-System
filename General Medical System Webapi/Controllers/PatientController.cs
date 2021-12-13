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
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientInfoBll _patientInfoBll;

        public PatientController(IMapper mapper, IPatientInfoBll patientInfoBll)
        {
            _mapper = mapper;
            _patientInfoBll = patientInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Patient
        [HttpGet]
        public async Task<ApiResult> Query()
        {
            var patients = await _patientInfoBll.GetAll().ToListAsync();
            var patientDtos = _mapper.Map<List<PatientDto>>(patients);
            if (patientDtos.Count != 0) return ApiResultHelp<List<PatientDto>>.SuccessResult(patientDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Get api/Patient/1
        [HttpGet("{id}")]
        public async Task<ApiResult> Query(string id)
        {
            var patients = await _patientInfoBll.GetEntities.Where(x => x.Id == id).ToListAsync();
            //使用Mapster转换成Dto
            var patientDtos = _mapper.Map<List<PatientDto>>(patients);
            if (patientDtos.Count != 0) return ApiResultHelp<List<PatientDto>>.SuccessResult(patientDtos);
            return ApiResultHelp.ErrorResult(404, "无数据");
        }

        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        /// post api/Patient
        [HttpPost]
        public async Task<ApiResult> Add(PatientInfo patientInfo)
        {
            if (await _patientInfoBll.AddAsync(patientInfo)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patientName"></param>
        /// <param name="phonenum"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// Update api/Patient/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string wardId, string patientName, string phonenum, string status)
        {
            var PatientInfo = await _patientInfoBll.FindAsync(id);
            if (PatientInfo != null)
            {
                PatientInfo.WardId = wardId;
                PatientInfo.PatientName = patientName;
                PatientInfo.Phonenum = phonenum;
                PatientInfo.Status = status;

                if (await _patientInfoBll.UpdateAsync(PatientInfo))
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
                return ApiResultHelp.ErrorResult(404, "没有这个患者");
            }
        }

        /// <summary>
        /// 按照id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Delete api/Patient/1
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(string id)
        {
            if (await _patientInfoBll.DeleteAsync(id)) return ApiResultHelp.SuccessResult();
            return ApiResultHelp.ErrorResult(405, "删除失败");
        }
    }
}