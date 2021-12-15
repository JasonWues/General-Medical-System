using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 住院表
    /// </summary>
    public class BehospitalizedInfo : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 病房Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string WardId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}