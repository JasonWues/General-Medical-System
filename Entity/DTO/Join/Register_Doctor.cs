namespace Entity.DTO.Join
{
    public class Register_Doctor_Patient
    {

        public string Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 挂号时间
        /// </summary>
        public string Registertime { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public string Paymenttime { get; set; }
    }
}
