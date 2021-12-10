using Entity;
using GeneralMedicalDal;
using IGeneralMedicalDal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GeneralMedicalContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//“¿¿µ◊¢»ÎDal≤„
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

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
