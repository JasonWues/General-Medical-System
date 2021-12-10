using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 科室表数据访问层接口
    /// </summary>
    public class DepartmentInfoDal : BaseDal<DepartmentInfo>, IDepartmentInfoDal
    {
        //数据上文
        private GeneralMedicalContext _DbContext;

        public DepartmentInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}