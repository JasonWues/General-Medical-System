using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 患者表
    /// </summary>
    public class PatientInfo : BaseId
    {
        /// <summary>
        /// 病房Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string WardId { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Column(TypeName = "varchar(18)")]
        public string Phonenum { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Password { get; set; }

        /// <summary>
        /// 患者状态
        /// </summary>
        [Column(TypeName = "nvarchar(12)")]
        public string? Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime Deletetime { get; set; }
    }
}