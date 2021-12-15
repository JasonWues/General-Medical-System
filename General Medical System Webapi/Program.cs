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

//InitDB();

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
    var contextOptions = new DbContextOptionsBuilder<GeneralMedicalContext>().UseSqlServer("server=.;database=GeneralMedicalSystem;Encrypt=True;TrustServerCertificate=True;Integrated Security=true;").Options;
    using (GeneralMedicalContext context = new(contextOptions))
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        MenuInfo parentMenu = new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "医院空间",
            Type = 0,
            Icon = "",
            Href = "",
            Sort = 0
        };

        context.MenuInfo.AddRange(parentMenu, new MenuInfo()
        {
            Id = Guid.NewGuid().ToString(),
            ParentId = parentMenu.Id,
            Title = "医生管理",
            Href = "../Doctor/Table.html",
            Icon = "",
            Type = 1,
            Opentype = "_iframe"
        });

        context.SaveChanges();
    }
}