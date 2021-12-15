using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    public class MenuInfoDal : BaseDal<MenuInfo>, IMenuInfoDal
    {
        private readonly GeneralMedicalContext _DbContext;
        public MenuInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
