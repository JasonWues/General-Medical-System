using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 生产厂家
    /// </summary>
    internal class ManufacturerInfo : BaseId
    {
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Column(TypeName = "nvarchar(18)")]
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Column(TypeName = "nvarchar(12)")]
        public string Contactperson { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Column(TypeName = "varchar(18)")]
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
