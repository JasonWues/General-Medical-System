﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    /// <summary>
    /// 菜单表
    /// </summary>

    public  record MenuDto
    {
       
            /// <summary>
            /// 父级id
            /// </summary>

            public string? ParentId { get; set; }
            /// <summary>
            /// 标题
            /// </summary>


            public string Title { get; set; }

            /// <summary>
            /// 0: 目录 1: 菜单
            /// </summary>
            public int Type { get; set; }
            /// <summary>
            /// 图标
            /// </summary>

        
            public string? Icon { get; set; }

            public int? Sort { get; set; }

            /// <summary>
            /// 链接
            /// </summary>

            public string? Href { get; set; }

            /// <summary>
            /// 打开类型 当 type 为 1 时，openType 生效，_iframe 正常打开 _blank 新建浏览器标签页
            /// </summary>
            public string? Opentype { get; set; }
        }
}
