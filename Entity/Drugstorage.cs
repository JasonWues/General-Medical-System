using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 药品库存
    /// </summary>
    public class DrugStorage : BaseId
    {
        /// <summary>
        /// 厂家Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 药品Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DrugId { get; set; }
        /// <summary>
        /// 出库人
        /// </summary>
        public string? OutgoerId { get; set; }

        /// <summary>
        /// 0出库1入库
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 入库人Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string? OperatorId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}