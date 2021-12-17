namespace Entity.DTO
{
    public record DrugStorageDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 厂家Id
        /// </summary>
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 药品Id
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 入库人Id
        /// </summary>
        public string? OperatorId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}