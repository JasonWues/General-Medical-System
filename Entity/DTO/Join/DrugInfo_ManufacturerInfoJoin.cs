using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.Join
{
    public class DrugInfo_ManufacturerInfoJoin
    {
        public string Id { get; set; }
        /// <summary>
        /// 生产厂家Id
        /// </summary>
        public string ManufacturerId { get; set; }

        public string ManufacturerName { get; set;}

        /// <summary>
        /// 药品Id
        /// </summary>
        public string DrugId { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugTitle { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 警戒数字
        /// </summary>
        public int Warningcount { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime Deletetime { get; set; }
    }
}
