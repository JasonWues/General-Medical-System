using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    /// <summary>
    /// 病房业务访问层
    /// </summary>
    public class WardInfoBll : BaseBll<WardInfo>, IWardInfoBll
    {
        public WardInfoBll(IWardInfoDal wardInfoDal)
        {
            _iBaseDal = wardInfoDal;
        }
    }
}