using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 诊断药品关联表数据访问层接口
    /// </summary>
    public class DiagnosisInfo_DrugInfoDal : BaseDal<DiagnosisInfo_DrugInfo>, IDiagnosisInfo_DrugInfoDal
    {
        /// <summary>
        /// 数据上文
        /// </summary>
        private GeneralMedicalContext _DbContext;

        public DiagnosisInfo_DrugInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}