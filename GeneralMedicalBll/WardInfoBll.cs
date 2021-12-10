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
    /// 病房业务访问层
    /// </summary>
    public  class WardInfoBll : BaseBll<WardInfo>,IWardInfoBll
    {
        public WardInfoBll(IWardInfoDal wardInfoDal)
        {
            _iBaseDal = wardInfoDal;
        }
    }
}
