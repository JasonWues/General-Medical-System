using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 基础父类实体
    /// </summary>
    public class BaseId
    {
        /// <summary>
        /// 主键
        /// </summary>

        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }
    }
}