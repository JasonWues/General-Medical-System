using System.ComponentModel.DataAnnotations.Schema;

/*
 * @date : 2021-12-9
 * @desc : 患者药品关联表 没有控制器
 */

namespace Entity
{
    public class DrugInfo_PatientInfo : BaseId
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string PatientId { get; set; }

        /// <summary>
        /// 药品Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DrugId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}