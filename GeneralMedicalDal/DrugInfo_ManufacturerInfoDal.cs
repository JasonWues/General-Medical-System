using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 生产厂家药品关联表数据访问层接口
    /// </summary>
    public class DrugInfo_ManufacturerInfoDal : BaseDal<DrugInfo_ManufacturerInfo>, IDrugInfo_ManufacturerInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public DrugInfo_ManufacturerInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}