using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 医生表
    /// </summary>
    public class DoctorInfo : BaseId
    {
        /// <summary>
        /// 科室Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string? DepartmentId { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [Column(TypeName = "nvarchar(18)")]
        public string DoctorName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 挂号金额
        /// </summary>
        [Column(TypeName = "money")]
        public decimal RegisteredPrice { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column(TypeName = "varchar(18)")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar(max)")]
        public string Password { get; set; }

        /// <summary>
        /// 添加时间
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