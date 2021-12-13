using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class GeneralMedicalContext : DbContext
    {
        public GeneralMedicalContext(DbContextOptions<GeneralMedicalContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=DESKTOP-QOGKNNM\SQLEXPRESS;database=CompanySystem;uid=sa;pwd=123456;");
            optionsBuilder.UseSqlServer("server=.;database=GeneralMedicalSystem;Integrated Security=true;");
        }

        public DbSet<BehospitalizedInfo> Behospitalized { get; set; }
        public DbSet<DepartmentInfo> DepartmentInfo { get; set; }
        public DbSet<DiagnosisInfo> DiagnosisInfo { get; set; }
        public DbSet<DiagnosisInfo_DrugInfo> DiagnosisInfo_DrugInfo { get; set; }
        public DbSet<DoctorInfo> DoctorInfo { get; set; }
        public DbSet<DoctorInfo_RoleInfo> DoctorInfo_RoleInfo { get; set; }
        public DbSet<DrugInfo> DrugInfo { get; set; }
        public DbSet<DrugInfo_ManufacturerInfo> Info_ManufacturerInfo { get; set; }
        public DbSet<DrugInfo_PatientInfo> DrugInfo_PatientInfo { get; set; }
        public DbSet<Drugstorage> Drugstorage { get; set; }
        public DbSet<ManufacturerInfo> ManufacturerInfo { get; set; }
        public DbSet<PatientInfo> PatientInfo { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<WardInfo> WardInfo { get; set; }
    }
}