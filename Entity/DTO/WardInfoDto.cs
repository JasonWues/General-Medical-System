namespace Entity.DTO
{
    public record WardInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 病房标题
        /// </summary>
        public string WardTitle { get; set; }

        /// <summary>
        /// 病房类别
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 病房床位
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 病房状态
        /// </summary>
        public string Status { get; set; }
    }
}
