﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 科室表
    /// </summary>
    public class DepartmentInfo : BaseId
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Departmentname { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string LeaderId { get; set; }

        /// <summary>
        /// 挂号数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 科室状态
        /// </summary>
        public int Status { get; set; }
    }
}
