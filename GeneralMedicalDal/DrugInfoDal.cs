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
    /// 药品表数据访问层接口
    /// </summary>
    public class DrugInfoDal:BaseDal<DrugInfo>,IDrugInfoDal
    {
        GeneralMedicalContext _DbContext;
        public DrugInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
