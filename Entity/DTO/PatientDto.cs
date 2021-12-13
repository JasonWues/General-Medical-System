﻿namespace Entity.DTO
{
    public record PatientDto
    {
        /// <summary>
        /// 病房Id
        /// </summary>
        public string? WardId { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phonenum { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 患者状态
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Createtime { get; set; }
    }
}
