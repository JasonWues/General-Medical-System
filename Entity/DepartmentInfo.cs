using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 科室表
    /// </summary>
    public class DepartmentInfo : BaseId
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string? LeaderId { get; set; }

        /// <summary>
        /// 挂号数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 科室状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}