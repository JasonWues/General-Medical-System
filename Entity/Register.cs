using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 挂号表
    /// </summary>
    public class Register : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "nvarchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DoctorId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 挂号时间
        /// </summary>
        public DateTime Registertime { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime Paymenttime { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public DateTime Treatmenttime { get; set; }
    }
}