using Entity;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 挂号表数据访问层接口
    /// </summary>
    public class RegisterDal:BaseDal<Register>, IRegisterDal
    {
        GeneralMedicalContext _DbContext;
        public RegisterDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
