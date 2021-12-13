namespace Entity.DTO
{
    public record RoleInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string? Authority { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}