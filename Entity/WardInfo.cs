using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 病房表
    /// </summary>
    public class WardInfo : BaseId
    {
        /// <summary>
        /// 病房标题
        /// </summary>
        [Column(TypeName = "varchar(12)")]
        public string WardTitle { get; set; }

        /// <summary>
        /// 病房类别
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 病房床位
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 病房状态
        /// </summary>
        public int Status { get; set; }

    }
}
