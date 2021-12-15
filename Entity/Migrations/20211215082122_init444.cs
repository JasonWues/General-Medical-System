using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class init444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Behospitalized",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    PatientId = table.Column<string>(type: "varchar(36)", nullable: false),
                    WardId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behospitalized", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "varchar(36)", nullable: false),
                    LeaderId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    PatientId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DoctorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisInfo_DrugInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    DiagnosisId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DrugidId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisInfo_DrugInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    DepartmentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RegisteredPrice = table.Column<decimal>(type: "money", nullable: false),
                    PhoneNum = table.Column<string>(type: "varchar(18)", nullable: false),
                    Password = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Deletetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInfo_RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    DoctorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInfo_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    DrugTitle = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    Unit = table.Column<string>(type: "varchar(10)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Warningcount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Deletetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugInfo_PatientInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    PatientId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DrugId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInfo_PatientInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugstorage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ManufacturerId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DrugId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<string>(type: "varchar(36)", nullable: false),
                    OperatorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugstorage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Info_ManufacturerInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ManufacturerId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DrugId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info_ManufacturerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturerInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    Contactperson = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Phonenum = table.Column<string>(type: "varchar(18)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    WardId = table.Column<string>(type: "varchar(36)", nullable: false),
                    PatientName = table.Column<string>(type: "varchar(36)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PhoneNum = table.Column<string>(type: "varchar(18)", nullable: false),
                    Password = table.Column<string>(type: "varchar(36)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Deletetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    DoctorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Registertime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paymenttime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Authority = table.Column<string>(type: "varchar(36)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Deletetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WardInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    WardTitle = table.Column<string>(type: "varchar(12)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Behospitalized");

            migrationBuilder.DropTable(
                name: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "DiagnosisInfo");

            migrationBuilder.DropTable(
                name: "DiagnosisInfo_DrugInfo");

            migrationBuilder.DropTable(
                name: "DoctorInfo");

            migrationBuilder.DropTable(
                name: "DoctorInfo_RoleInfo");

            migrationBuilder.DropTable(
                name: "DrugInfo");

            migrationBuilder.DropTable(
                name: "DrugInfo_PatientInfo");

            migrationBuilder.DropTable(
                name: "Drugstorage");

            migrationBuilder.DropTable(
                name: "Info_ManufacturerInfo");

            migrationBuilder.DropTable(
                name: "ManufacturerInfo");

            migrationBuilder.DropTable(
                name: "PatientInfo");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "WardInfo");
        }
    }
}
