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
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentInfoBll _departmentInfoBll;
        public DepartmentController(IMapper mapper,IDepartmentInfoBll departmentInfoBll)
        {
            _mapper = mapper;
            _departmentInfoBll = departmentInfoBll;
        }

        [HttpGet]
        public async Task<ApiResult> Query()
        {
            var departments = await _departmentInfoBll.GetAll().ToListAsync();
            var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);
            if(departmentDtos.Count != 0)return ApiResultHelp<List<DepartmentDto>>.SuccessResult(departmentDtos);
            return ApiResultHelp.ErrorResult(404,"无数据");
        }
    }
}
