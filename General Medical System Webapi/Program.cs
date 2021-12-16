using Entity;
using GeneralMedicalBll;
using GeneralMedicalDal;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text;
using Utility;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
Console.OutputEncoding = Encoding.Unicode;
Log.Logger = new LoggerConfiguration()
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
    opt.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<GeneralMedicalContext>();
builder.Services.AddEndpointsApiExplorer();

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
builder.Services.AddScoped<IDrugstorageDal, DrugstorageDal>();
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
builder.Services.AddScoped<IDrugstorageBll, DrugstorageBll>();
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

InitDB();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

static void InitDB()
{
    Log.Information("创建数据库");
    var contextOptions = new DbContextOptionsBuilder<GeneralMedicalContext>().UseSqlServer(@"server=DESKTOP-QOGKNNM\SQLEXPRESS;database=GeneralMedicalSystem;Encrypt=True;TrustServerCertificate=True;uid=sa;pwd=123456;").Options;
    using (GeneralMedicalContext context = new(contextOptions))
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
            
        MenuInfo parentMenu = new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "医院管理",
            Type = 0,
            Icon = "",
            Href = "",
            Sort = 200
        };
        #region 初始化菜单
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
            Title = "科室管理",
            Href = "../Department/Table.html",
            Sort = 205,
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
        #endregion

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
        #endregion

        context.SaveChanges();
    }
}