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
    /// 诊断表数据访问层接口
    /// </summary>
    public class DiagnosisInfoDal:BaseDal<DiagnosisInfo>,IDiagnosisInfoDal
    {
        //数据上文
        GeneralMedicalContext _DbContext;
        public DiagnosisInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
