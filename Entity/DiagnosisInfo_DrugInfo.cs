using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 诊断药品关联表 没有控制器
    /// </summary>
    public class DiagnosisInfo_DrugInfo : BaseId
    {
        /// <summary>
        /// 诊断Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DiagnosisId { get; set; }

        /// <summary>
        /// 药品Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DrugidId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}