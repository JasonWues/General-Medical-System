using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleInfo : BaseId
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column(TypeName = "nvarchar(18)")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [Column(TypeName = "nvarchar(80)")]
        public string? Description { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string? Authority { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

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