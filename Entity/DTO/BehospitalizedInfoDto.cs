namespace Entity.DTO
{
    public record BehospitalizedInfoDto
    {
        public string Id { get; set; }
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
        public string Createtime { get; set; }
    }
}