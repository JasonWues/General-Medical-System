﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class MenuInfo : BaseId
    {
        [Column(TypeName = "varchar(36)")]
        public string? ParentId { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string Title { get; set; }

        /// <summary>
        /// 0: 目录 1: 菜单
        /// </summary>
        public int Type { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string? Icon { get; set; }

        public int? Sort { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Column(TypeName = "varchar(128)")]
        public string? Href { get; set; }

        /// <summary>
        /// 打开类型 当 type 为 1 时，openType 生效，_iframe 正常打开 _blank 新建浏览器标签页
        /// </summary>
        public string? Opentype { get; set; }

    }
}
