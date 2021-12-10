using Entity;
using IGeneralMedicalDal;

namespace GeneralMedicalDal
{
    /// <summary>
    /// 患者药品关联表据访问层接口
    /// </summary>
    public class DrugInfo_PatientInfoDal : BaseDal<DrugInfo_PatientInfo>, IDrugInfo_PatientInfoDal
    {
        private GeneralMedicalContext _DbContext;

        public DrugInfo_PatientInfoDal(GeneralMedicalContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}