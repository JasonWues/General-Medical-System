using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalBll
{
    /// <summary>
    /// 角色业务访问层
    /// </summary>
    public class RoleInfoBll : BaseBll<RoleInfo>,IRoleInfoBll
    {
        public RoleInfoBll(IRoleInfoDal roleInfoDal)
        {
           _iBaseDal = roleInfoDal; 
        }
    }
}
