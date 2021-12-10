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
    /// 诊断药品关联表数据访问层接口
    /// </summary>
    public class DiagnosisInfo_DrugInfoDal:BaseDal<DiagnosisInfo_DrugInfo>,IDiagnosisInfo_DrugInfoDal
    {
        /// <summary>
        /// 数据上文
        /// </summary>
        GeneralMedicalContext _DbContext;
        public DiagnosisInfo_DrugInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
