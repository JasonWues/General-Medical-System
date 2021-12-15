using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 病房表数据访问层接口
    /// </summary>
    public class WardInfoDal : BaseDal<WardInfo>, IWardInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public WardInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}