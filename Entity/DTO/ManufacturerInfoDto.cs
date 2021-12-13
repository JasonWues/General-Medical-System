
namespace Entity.DTO
{
    public record ManufacturerInfoDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>

        public string ManufacturerName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
     
        public string Contactperson { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>

        public string Phonenum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}
