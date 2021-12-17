using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 药品库存数据访问层接口
    /// </summary>
    public class DrugStorageDal : BaseDal<DrugStorage>, IDrugStorageDal
    {
        private GeneralMedicalContext _DbContext;

        public DrugStorageDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}