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
    /// 患者表数据访问层接口
    /// </summary>
    public class PatientInfoDal:BaseDal<PatientInfo>, IPatientInfoDal
    {
        GeneralMedicalContext _DbContext;
         public PatientInfoDal(GeneralMedicalContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
