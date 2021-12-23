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
    /// 患者控制器
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientInfoBll _patientInfoBll;
        private readonly IWardInfoBll _wardInfoBll;

        public PatientController(IMapper mapper, IPatientInfoBll patientInfoBll, IWardInfoBll wardInfoBll)
        {
            _mapper = mapper;
            _patientInfoBll = patientInfoBll;
            _wardInfoBll = wardInfoBll;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// Get api/Patient
        [HttpGet]
        public async Task<ApiResult> Query(int page, int limit, string? patientName, string? phoneNum)
        {
            var (patients, count) = await _patientInfoBll.Query(page, limit, patientName, phoneNum);
            if (patients.Count != 0) return ApiResultHelp<List<Patient_Ward>>.SuccessResult(patients, count);
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
            var patients = await _patientInfoBll.FindAsync(id);
            //使用Mapster转换成Dto
            //var patientDtos = _mapper.Map<PatientDto>(patients);
            if (patients != null) return ApiResultHelp<PatientInfo>.SuccessResult(patients);
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
            patientInfo.Createtime = DateTime.Now;

            WardInfo wardInfo = await _wardInfoBll.GetEntities.FirstAsync(x => x.Id == patientInfo.WardId && x.Status == 1);

            if (wardInfo.Num == 0)
            {
                return ApiResultHelp.ErrorResult(405, "该病房床位已满");
            }
            else
            {
                wardInfo.Num -= 1;
                await _wardInfoBll.UpdateAsync(wardInfo);

                if (wardInfo.Num == 0)
                {
                    wardInfo.Status = 0;
                    await _wardInfoBll.UpdateAsync(wardInfo);
                }

                if (await _patientInfoBll.AddAsync(patientInfo)) return ApiResultHelp.SuccessResult();
            }


            return ApiResultHelp.ErrorResult(405, "添加失败");
        }

        /// <summary>
        /// 按id更新部分数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patientName"></param>
        /// <param name="phoneNum"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// Update api/Patient/1
        [HttpPatch("{id}")]
        public async Task<ApiResult> Update(string id, string wardId, string patientName, string phoneNum, int status)
        {
            WardInfo wardInfo = await _wardInfoBll.GetEntities.FirstAsync(x => x.Id == wardId && x.Status == 0);

            var PatientInfo = await _patientInfoBll.FindAsync(id);
            if (PatientInfo != null)
            {
                PatientInfo.WardId = wardId;
                PatientInfo.PatientName = patientName;
                PatientInfo.PhoneNum = phoneNum;
                PatientInfo.Status = status;

                if (await _patientInfoBll.UpdateAsync(PatientInfo))
                {
                    if (wardInfo != null)
                    {
                        wardInfo.Num += 1;
                        wardInfo.Status = 1;

                        await _wardInfoBll.UpdateAsync(wardInfo);

                    }

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

        [HttpGet("wardOption")]
        public async Task<List<WardInfo>> GetSelectOption()
        {
            //await _patientInfoBll.GetEntities.Where(p=>p.WardId)
            //await _wardInfoBll.GetEntities.Where(w=>w.)


            var option = await _wardInfoBll.GetEntities.Where(w => w.Status == 1).Select(x => new WardInfo
            {
                Id = x.Id,
                WardTitle = x.WardTitle,
            }).ToListAsync();



            if (option.Count != 0) return option;
            return new List<WardInfo>();
        }
    }
}