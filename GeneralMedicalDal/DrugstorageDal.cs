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
    /// 药品库存数据访问层接口
    /// </summary>
    public class DrugstorageDal:BaseDal<Drugstorage>, IDrugstorageDal
    {
        GeneralMedicalContext _DbContext;
        public DrugstorageDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
