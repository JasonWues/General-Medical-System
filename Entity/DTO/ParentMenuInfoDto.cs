namespace Entity.DTO
{
    public class ParentMenuInfoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Icon { get; set; }
        public string? Herf { get; set; }
        public List<MenuInfo>? ChildMenuInfo { get; set; }
    }
}
