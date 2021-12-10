using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 诊断表数据访问层接口
    /// </summary>
    public class DiagnosisInfoDal : BaseDal<DiagnosisInfo>, IDiagnosisInfoDal
    {
        //数据上文
        private GeneralMedicalContext _DbContext;

        public DiagnosisInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}