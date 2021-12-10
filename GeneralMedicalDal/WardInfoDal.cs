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
    /// 病房表数据访问层接口
    /// </summary>
    public class WardInfoDal:BaseDal<WardInfo>, IWardInfoDal
    {
        GeneralMedicalContext _DbContext;
        public WardInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
