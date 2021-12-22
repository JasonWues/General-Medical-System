namespace Entity.DTO.Join
{
    public class DrugStorage_Drug_Manufacturer_Doctor
    {
        public string Id { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        public string? ManufacturerName { get; set; }


        /// <summary>
        /// 出库医生姓名
        /// </summary>

        public string OutgoerDoctorName { get; set; }

        /// <summary>
        /// 入库医生姓名
        /// </summary>

        public string OperatorDoctorName { get; set; }

        /// <summary>
        /// 0出库1入库
        /// </summary>
        public string Type { get; set; }

        public string DrugTitle { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}
