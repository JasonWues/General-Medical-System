using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 诊断表
    /// </summary>
    public class DiagnosisInfo : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DoctorId { get; set; }

        /// <summary>
        /// 诊断意见
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Opinion { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}
