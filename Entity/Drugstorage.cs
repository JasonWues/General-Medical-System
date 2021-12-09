using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 药品库存
    /// </summary>
    public class Drugstorage : BaseId
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
        ///数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ApplicantId { get; set; }

        /// <summary>
        /// 入库人Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}
