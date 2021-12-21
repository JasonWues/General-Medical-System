namespace Entity.DTO.Join
{
    public class Department_Doctor
    {
        public string Id { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        public string? LeaderId { get; set; }

        public string? LeaderName { get; set; }

        /// <summary>
        /// 挂号数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 科室状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Createtime { get; set; }
    }
}