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
    /// 住院表数据访问层接口
    /// </summary>
    public class BehospitalizedDal:BaseDal<Behospitalized>,IBehospitalizedDal
    {
        //数据上文
        GeneralMedicalContext _DbContext;
        public BehospitalizedDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
