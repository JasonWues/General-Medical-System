using IGeneralMedicalBll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utility;

namespace General_Medical_System_Webapi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDoctorInfoBll _doctorInfoBll;
        private readonly IDoctorInfo_RoleInfoBll _doctorInfoRoleBll;
        private readonly IRoleInfoBll _roleInfoBll;

        public LoginController(IDoctorInfoBll doctorInfoBll, IDoctorInfo_RoleInfoBll doctorInfo_RoleInfoBll, IRoleInfoBll roleInfoBll)
        {
            _doctorInfoBll = doctorInfoBll;
            _doctorInfoRoleBll = doctorInfo_RoleInfoBll;
            _roleInfoBll = roleInfoBll;
        }

        [HttpPost]
        public async Task<ApiResult> Login([FromForm] string phoneNum, [FromForm] string password)
        {
            var doctorInfo = _doctorInfoBll.GetEntities.Where(x => x.IsDelete == false);
            //MD5加密
            string pwd = MD5Helper.MD5Encrypt32(password);

            var doctorEntity = await _doctorInfoBll.GetEntities.FirstAsync(x => x.PhoneNum == phoneNum && x.Password == pwd);
            if (doctorEntity != null)
            {
                //获取当前绑定的角色名称
                var rolesName = await (from doctor in doctorInfo
                                       join doctor_role in _doctorInfoRoleBll.GetEntities
                                       on doctor.Id equals doctor_role.DoctorId

                                       join role in _roleInfoBll.GetEntities
                                       on doctor_role.RoleId equals role.Id
                                       select role.RoleName).ToListAsync();

                //该用户的声明（简单来说就是信息）
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,doctorEntity.DoctorName),
                    new Claim("Id",doctorEntity.Id),
                    new Claim("PhoneNum",doctorEntity.PhoneNum),
                };
                claims.AddRange(rolesName.Select(x => new Claim(ClaimTypes.Role, x)));

                //加密密钥
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXXC-PRZ5-SAD-DFSFA-METATRX-ON"));

                //加密方式
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7283",
                    audience: "https://localhost:7283",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: creds
                    );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelp.SuccessResult(jwtToken);
            }
            else
            {
                return ApiResultHelp.ErrorResult(404, "没有这个医生");
            }
        }
    }
}