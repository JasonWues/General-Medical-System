using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class MenuInfo : BaseId
    {
        /// <summary>
        /// 父级id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string? ParentId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>

        [Column(TypeName = "nvarchar(16)")]
        public string Title { get; set; }

        /// <summary>
        /// 0: 目录 1: 菜单
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 图标
        /// </summary>

        [Column(TypeName = "varchar(32)")]
        public string? Icon { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

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
