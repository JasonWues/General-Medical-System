/*
 * @date : 2021-12-9
 * @desc : 医生角色关联表
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class DoctorInfo_RoleInfo : BaseId
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DoctorId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}