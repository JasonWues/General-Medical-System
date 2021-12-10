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
    /// 医生表数据访问层接口
    /// </summary>
    public class DoctorInfoDal:BaseDal<DoctorInfo>,IDoctorInfoDal 
    {
        GeneralMedicalContext _DbContext;
        public DoctorInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
