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
    /// 角色表数据访问层接口
    /// </summary>
    public class RoleInfoDal:BaseDal<RoleInfo>, IRoleInfoDal
    {
        GeneralMedicalContext _DbContext;
        public RoleInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
