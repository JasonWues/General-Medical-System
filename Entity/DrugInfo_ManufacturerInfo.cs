﻿/*
 * @date : 2021-12-9
 * @desc : 生产厂家药品关联表 没有控制器
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class DrugInfo_ManufacturerInfo : BaseId
    {
        /// <summary>
        /// 生产厂家Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ManufacturerId { get; set; }

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