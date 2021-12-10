using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class ManufacturerInfoBll : BaseBll<ManufacturerInfo>, IManufacturerInfoBll
    {
        public ManufacturerInfoBll(IManufacturerInfoDal manufacturerInfoDal)
        {
            _iBaseDal = manufacturerInfoDal;
        }
    }
}