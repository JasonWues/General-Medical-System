namespace Entity.DTO
{
    public record BehospitalizedInfoDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 病房Id
        /// </summary>
        public string WardId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}