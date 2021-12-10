using Entity;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 生产厂家药品关联表数据访问层接口
    /// </summary>
    public class DrugInfo_ManufacturerInfoDal:BaseDal<DrugInfo_ManufacturerInfo>, IDrugInfo_ManufacturerInfoDal
    {
        GeneralMedicalContext _DbContext;
        public DrugInfo_ManufacturerInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
