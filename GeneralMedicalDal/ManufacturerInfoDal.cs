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
    /// 生产厂家表数据访问层接口
    /// </summary>
    public class ManufacturerInfoDal:BaseDal<ManufacturerInfo>, IManufacturerInfoDal
    {
        GeneralMedicalContext _DbContext;
        public ManufacturerInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
