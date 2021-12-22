using Entity;
using GeneralMedicalBll;
using GeneralMedicalDal;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using Utility;

Console.OutputEncoding = Encoding.Unicode;
Log.Logger = new LoggerConfiguration()
                .Enrich.WithThreadId()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
                .CreateLogger();

Log.Information("启动主机");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

//跨域
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<GeneralMedicalContext>();
builder.Services.AddEndpointsApiExplorer();

InitDB();

//JWT
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "直接在下框中输入Bearer {token} 注意两者之间是一个空格",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

#region IOC

builder.Services.AddScoped<IDoctorInfoDal, DoctorInfoDal>();
builder.Services.AddScoped<IBehospitalizedDal, BehospitalizedDal>();
builder.Services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
builder.Services.AddScoped<IDiagnosisInfo_DrugInfoDal, DiagnosisInfo_DrugInfoDal>();
builder.Services.AddScoped<IDiagnosisInfoDal, DiagnosisInfoDal>();
builder.Services.AddScoped<IDoctorInfo_RoleInfoDal, DoctorInfo_RoleinfoDal>();
builder.Services.AddScoped<IDrugInfo_ManufacturerInfoDal, DrugInfo_ManufacturerInfoDal>();
builder.Services.AddScoped<IDrugInfo_PatientInfoDal, DrugInfo_PatientInfoDal>();
builder.Services.AddScoped<IDrugInfoDal, DrugInfoDal>();
builder.Services.AddScoped<IDrugStorageDal, DrugStorageDal>();
builder.Services.AddScoped<IManufacturerInfoDal, ManufacturerInfoDal>();
builder.Services.AddScoped<IPatientInfoDal, PatientInfoDal>();
builder.Services.AddScoped<IRegisterDal, RegisterDal>();
builder.Services.AddScoped<IRoleInfoDal, RoleInfoDal>();
builder.Services.AddScoped<IWardInfoDal, WardInfoDal>();
builder.Services.AddScoped<IMenuInfoDal, MenuInfoDal>();

builder.Services.AddScoped<IDoctorInfoBll, DoctorInfoBll>();
builder.Services.AddScoped<IBehospitalizedBll, BehospitalizedBll>();
builder.Services.AddScoped<IDepartmentInfoBll, DepartmentInfoBll>();
builder.Services.AddScoped<IDiagnosisInfo_DrugInfoBll, DiagnosisInfo_DrugInfoBll>();
builder.Services.AddScoped<IDiagnosisInfoBll, DiagnosisInfoBll>();
builder.Services.AddScoped<IDoctorInfo_RoleInfoBll, DoctorInfo_RoleInfoBll>();
builder.Services.AddScoped<IDrugInfo_ManufacturerInfoBll, DrugInfo_ManufacturerInfoBll>();
builder.Services.AddScoped<IDrugInfo_PatientInfoBll, DrugInfo_PatientInfoBll>();
builder.Services.AddScoped<IDrugInfoBll, DrugInfoBll>();
builder.Services.AddScoped<IDrugStorageBll, DrugStorageBll>();
builder.Services.AddScoped<IManufacturerInfoBll, ManufacturerInfoBll>();
builder.Services.AddScoped<IPatientInfoBll, PatientInfoBll>();
builder.Services.AddScoped<IRegisterBll, RegisterBll>();
builder.Services.AddScoped<IRoleInfoBll, RoleInfoBll>();
builder.Services.AddScoped<IWardInfoBll, WardInfoBll>();
builder.Services.AddScoped<IMenuInfoBll, MenuInfoBll>();

#endregion IOC

#region Mapster

TypeAdapterConfig config = new TypeAdapterConfig();
config.Scan(typeof(DtoRegister).Assembly);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

#endregion Mapster

#region JWT

builder.Services.AddCustomJWT();

#endregion JWT

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseCors();

app.UseAuthentication();//鉴权

app.UseAuthorization();//授权

app.MapControllers();

app.Run();

static void InitDB()
{
    Log.Information("创建数据库");
    var contextOptions = new DbContextOptionsBuilder<GeneralMedicalContext>().UseSqlServer(@"server=47.99.147.45;database=GeneralMedicalSystem;Encrypt=True;TrustServerCertificate=True;Uid=sa;Pwd=234500Prz..;").Options;
    using (GeneralMedicalContext context = new(contextOptions))
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        #region 初始化角色

        var RoleInfo = new RoleInfo()
        {
            RoleName = "管理员",
            Description = "我是管理员",
            Authority = "管理员",
            Sort = 0,
            Createtime = DateTime.Now
        };

        var RoleInfo2 = new RoleInfo
        {
            RoleName = "医生",
            Description = "我是医生",
            Authority = "医生",
            Sort = 1,
            Createtime = DateTime.Now
        };

        context.RoleInfo.AddRange(RoleInfo, RoleInfo2);

        #endregion 初始化角色

        #region 初始化菜单

        MenuInfo parentMenu = new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "医院管理",
            Type = 0,
            Icon = "",
            Href = "",
            Sort = 200
        };

        context.MenuInfo.AddRange(parentMenu, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "医生管理",
            Href = "../Doctor/Table.html",
            Sort = 200,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "科室管理",
            Href = "../Department/Table.html",
            Sort = 201,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "药品管理",
            Href = "../Drug/Table.html",
            Sort = 202,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "药品库存管理",
            Href = "../Drugstorage/Table.html",
            Sort = 203,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "制造商管理",
            Href = "../Manufacturer/Table.html",
            Sort = 204,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "菜单管理",
            Href = "../Menu/Table.html",
            Sort = 206,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "患者管理",
            Href = "../Patient/Table.html",
            Sort = 207,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "角色管理",
            Href = "../Role/Table.html",
            Sort = 208,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        }, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "病房管理",
            Href = "../Ward/Table.html",
            Sort = 209,
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        });

        #endregion 初始化菜单

        #region 初始化病房数据

        context.WardInfo.AddRange(new WardInfo()
        {
            Id = Guid.NewGuid().ToString(),
            WardTitle = "101",
            Type = 0,
            Num = 3,
            Status = 0
        }, new WardInfo
        {
            Id = Guid.NewGuid().ToString(),
            WardTitle = "102",
            Type = 1,
            Num = 2,
            Status = 1
        });

        #endregion 初始化病房数据

        #region 初始化医生数据

        var Doctor = new DoctorInfo()
        {
            DoctorName = "宋江",
            Age = 35,
            Sex = 0,
            Status = 0,
            RegisteredPrice = 6,
            PhoneNum = "123456",
            Password = MD5Helper.MD5Encrypt32("123456"),
            Createtime = DateTime.Now
        };

        context.DoctorInfo.AddRange(Doctor, new DoctorInfo()
        {
            DoctorName = "李逵",
            Age = 33,
            Sex = 0,
            Status = 0,
            RegisteredPrice = 3,
            PhoneNum = "12345678119",
            Password = MD5Helper.MD5Encrypt32("123456"),
            Createtime = DateTime.Now
        });

        #endregion 初始化医生数据

        #region 初始化医生角色数据

        context.AddRange(new DoctorInfo_RoleInfo()
        {
            DoctorId = Doctor.Id,
            RoleId = RoleInfo.Id,
            Createtime = DateTime.Now
        }, new DoctorInfo_RoleInfo()
        {
            DoctorId = Doctor.Id,
            RoleId = RoleInfo2.Id,
            Createtime = DateTime.Now
        });

        #endregion 初始化医生角色数据

        #region 初始化科室数据

        context.DepartmentInfo.AddRange(new DepartmentInfo()
        {
            Id = Guid.NewGuid().ToString(),
            DepartmentName = "儿科",
            Count = 0,
            Status = 0,
            Createtime = DateTime.Now
        }, new DepartmentInfo
        {
            Id = Guid.NewGuid().ToString(),
            DepartmentName = "外科",
            Count = 0,
            Status = 0,
            Createtime = DateTime.Now
        });

        #endregion 初始化科室数据

        #region 初始化患者数据

        context.PatientInfo.AddRange(new PatientInfo()
        {
            WardId = Guid.NewGuid().ToString(),
            PatientName = "张三",
            Age = 20,
            Sex = 0,
            PhoneNum = "13909302941",
            Password = "123456",
            Status = 0,
            Createtime = DateTime.Now
        });

        #endregion 初始化患者数据

        #region 初始化制造商数据

        context.ManufacturerInfo.AddRange(new ManufacturerInfo()
        {
            ManufacturerName = "小葵花厂",
            Contactperson = "小葵花",
            Phonenum = "700800900",
            Status = 1,
            Createtime = DateTime.Now
        });

        #endregion 初始化制造商数据

        context.SaveChanges();
    }
}

//扩展方法
public static class Extend
{
    //鉴权认证
    public static IServiceCollection AddCustomJWT(this IServiceCollection service)
    {
        service.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXXC-PRZ5-SAD-DFSFA-METATRX-ON")),
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:7283",
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:7283",
                    ValidateLifetime = true,//是否验证失效时间
                    ClockSkew = TimeSpan.FromMilliseconds(40)//缓冲时间
                };
            });
        return service;
    }
}