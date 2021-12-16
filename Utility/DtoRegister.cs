﻿using Entity;
using Entity.DTO;
using Mapster;

namespace Utility
{
    public class DtoRegister : IRegister
    {
        //配置映射
        public void Register(TypeAdapterConfig config)
        {
            //Doctor
            config.NewConfig<DoctorInfo, DoctorInfoDto>()
                .Map(dest => dest.Sex, src => src.Sex == 0 ? "男" : "女")
                .Map(dest => dest.Status,src => src.Status == 0 ? "正常" : "休假")
                .Map(dest => dest.RegisteredPrice, src => (int)src.RegisteredPrice)
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Department
            config.NewConfig<DepartmentInfo, DepartmentDto>()
                .Map(dest => dest.Status, src => src.Status == false ? "关闭" : "开启")
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Manufacturer
            config.NewConfig<ManufacturerInfo, ManufacturerInfoDto>()
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Patient
            config.NewConfig<PatientInfo, PatientDto>()
                .Map(dest => dest.Sex, src => src.Sex == 0 ? "男" : "女")
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Role
            config.NewConfig<RoleInfo, RoleInfoDto>()
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Drugstorage
            config.NewConfig<Drugstorage, DrugstorageDto>()
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));
        }
    }
}