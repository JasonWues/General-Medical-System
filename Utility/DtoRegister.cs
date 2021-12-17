using Entity;
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
                .Map(dest => dest.Status, src => src.Status == 0 ? "开启" : "关闭")
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Drug
            config.NewConfig<DrugInfo, DrugInfoDto>()
                .Map(dest => dest.Type, src => src.Type == 0 ? "处方药" : "非处方药")
                .Map(dest => dest.Price, src => (int)src.Price)
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Manufacturer
            config.NewConfig<ManufacturerInfo, ManufacturerInfoDto>()
                .Map(dest => dest.Status,src => src.Status == 0 ? "关闭" : "开启")
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Patient
            config.NewConfig<PatientInfo, PatientDto>()
                .Map(dest => dest.Sex, src => src.Sex == 0 ? "男" : "女")
                .Map(dest => dest.Status,src => src.Status == 0 ? "住院" : "出院")
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //Role
            config.NewConfig<RoleInfo, RoleInfoDto>()
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //DrugStorage
            config.NewConfig<DrugStorage, DrugStorageDto>()
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));

            //MenuInfo
            config.NewConfig<MenuInfo, MenuInfoDto>()
                .Map(dest => dest.Type, src => src.Type == 0 ? "目录" : "菜单")
                .Map(dest => dest.Opentype, src => src.Opentype == "_iframe" ? "正常打开" : "新建浏览器标签页");

            //Ward
            config.NewConfig<WardInfo, WardInfoDto>()
                .Map(dest => dest.Type, src => src.Type == 0 ? "普通病房" : "重症病房")
                .Map(dest => dest.Status, src => src.Status == 0 ? "满员" : "有空床");
        }
    }
}