using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 挂号表数据访问层接口
    /// </summary>
    public class RegisterDal : BaseDal<Register>, IRegisterDal
    {
        private GeneralMedicalContext _DbContext;

        public RegisterDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}