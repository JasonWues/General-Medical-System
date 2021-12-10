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
    /// 科室表数据访问层接口
    /// </summary>
    public class DepartmentInfoDal:BaseDal<DepartmentInfo>, IDepartmentInfoDal
    {
        //数据上文
        GeneralMedicalContext _DbContext;
        public DepartmentInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
