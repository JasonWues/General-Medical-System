using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 药品表
    /// </summary>
    public class DrugInfo : BaseId
    {
        /// <summary>
        /// 药品名称
        /// </summary>
        [Column(TypeName = "nvarchar(26)")]
        public string DrugTitle { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(TypeName = "nvarchar(10)")]
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
        public int Type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [Column(TypeName = "nvarchar(36)")]
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime Deletetime { get; set; }
    }
}