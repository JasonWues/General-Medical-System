using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 生产厂家表数据访问层接口
    /// </summary>
    public class ManufacturerInfoDal : BaseDal<ManufacturerInfo>, IManufacturerInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public ManufacturerInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}