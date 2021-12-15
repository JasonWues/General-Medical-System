using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 医生角色关联表 没有控制器
    /// </summary>
    public class DoctorInfo_RoleInfo : BaseId
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DoctorId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}