using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 住院表数据访问层接口
    /// </summary>
    public class BehospitalizedDal : BaseDal<BehospitalizedInfo>, IBehospitalizedDal
    {
        //数据上文
        private GeneralMedicalContext _DbContext;

        public BehospitalizedDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}