namespace Entity.DTO
{
    public record DiagnosisInfoDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        public string DoctorId { get; set; }
        /// <summary>
        /// 诊断意见
        /// </summary>
        public string Opinion { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}