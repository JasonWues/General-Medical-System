using Entity;
using GeneralMedicalBll;
using GeneralMedicalDal;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Mapster;
using MapsterMapper;
using Utility;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
                .CreateLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

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

    #endregion IOC

    #region Mapster

    TypeAdapterConfig config = new TypeAdapterConfig();
    config.Scan(typeof(DtoRegister).Assembly);
    builder.Services.AddSingleton(config);
    builder.Services.AddScoped<IMapper, ServiceMapper>();

    #endregion Mapster

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

