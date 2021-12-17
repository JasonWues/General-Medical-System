using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 药品库存数据访问层接口
    /// </summary>
    public class DrugstorageDal : BaseDal<DrugStorage>, IDrugstorageDal
    {
        private GeneralMedicalContext _DbContext;

        public DrugstorageDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}