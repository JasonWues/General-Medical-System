using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 患者药品关联表 没有控制器
    /// </summary>
    public class DrugInfo_PatientInfo : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 药品Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DrugId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}