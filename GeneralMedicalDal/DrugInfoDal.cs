using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 药品表数据访问层接口
    /// </summary>
    public class DrugInfoDal : BaseDal<DrugInfo>, IDrugInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public DrugInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}