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
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDoctorInfoBll _doctorInfoBll;
        public LoginController(IDoctorInfoBll doctorInfoBll)
        {
            _doctorInfoBll = doctorInfoBll;
        }

        [HttpPost("token")]
        public async Task<ApiResult> Login(string phoneNum,string password)
        {
            var doctorInfo = _doctorInfoBll.GetEntities.Where(x => x.IsDelete == false);
            //MD5加密
            string pwd = MD5Helper.MD5Encrypt32(password);

            var doctorEntity = await _doctorInfoBll.GetEntities.FirstAsync(x => x.PhoneNum == phoneNum && x.Password == pwd);
            if (doctorEntity != null)
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,doctorEntity.DoctorName),
                    new Claim("Id",doctorEntity.Id),
                    new Claim("PhoneNum",doctorEntity.PhoneNum)
                };

                //加密密钥
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXXC-PRZ5-SAD-DFSFA-METATRX-ON"));

                //加密方式
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7283",
                    audience: "https://localhost:7283",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                    );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelp.SuccessResult(jwtToken);
            }
            else
            {
                return ApiResultHelp.ErrorResult(404,"没有这个医生");
            }
        }
    }
}
