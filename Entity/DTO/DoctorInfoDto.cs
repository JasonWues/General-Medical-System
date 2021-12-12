namespace Entity.DTO
{
    public record DoctorInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string? DepartmentId { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 挂号金额
        /// </summary>
        public int RegisteredPrice { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phonenum { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}