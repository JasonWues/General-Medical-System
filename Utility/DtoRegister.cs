using Entity;
using Entity.DTO;
using Mapster;

namespace Utility
{
    public class DtoRegister : IRegister
    {

        //public static void InitMapster()
        //{
        //    TypeAdapterConfig<DoctorInfo, DoctorInfoDto>
        //        .NewConfig()
        //        .Map(dest => dest.Sex, src => src.Sex == 0 ? "男" : "女")
        //        .Map(dest => dest.RegisteredPrice, src => (int)src.RegisteredPrice)
        //        .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));
        //}

        //初始化Mapster
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DoctorInfo, DoctorInfoDto>()
                .Map(dest => dest.Sex, src => src.Sex == 0 ? "男" : "女")
                .Map(dest => dest.RegisteredPrice, src => (int)src.RegisteredPrice)
                .Map(dest => dest.Createtime, src => src.Createtime.ToString("g"));
        }
    }
}
