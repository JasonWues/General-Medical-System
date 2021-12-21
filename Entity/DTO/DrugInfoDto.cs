namespace Entity.DTO
{
    public record DrugInfoDto
    {
        /// <summary>
        /// 药品Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugTitle { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 警戒数字
        /// </summary>
        public int Warningcount { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}