namespace Entity.DTO
{
    public class ParentMenuInfoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Icon { get; set; }
        public string? Href { get; set; }

        /// <summary>
        /// 打开类型 当 type 为 1 时，openType 生效，_iframe 正常打开 _blank 新建浏览器标签页
        /// </summary>
        public string? Opentype { get; set; }

        public List<ParentMenuInfoDto>? Children { get; set; }
    }
}