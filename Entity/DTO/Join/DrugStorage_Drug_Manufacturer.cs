using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.Join
{
    public class DrugStorage_Drug_Manufacturer
    {
        public string Id { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        public string? ManufacturerId { get; set; }

        public string? ManufacturerName { get; set; }



        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugId { get; set; }
        public string DrugTitle { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// 入库人Id
        /// </summary>
 
        public string? OperatorId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string Createtime { get; set; }
    }
}
