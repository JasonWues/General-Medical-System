using System.ComponentModel.DataAnnotations.Schema;

/*
 * @date : 2021-12-9
 * @desc : 住院表
 */

namespace Entity
{
    public class Behospitalized : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 病房Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string WardId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}