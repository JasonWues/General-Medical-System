using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DrugInfo_ManufacturerInfoBll : BaseBll<DrugInfo_ManufacturerInfo>, IDrugInfo_ManufacturerInfoBll
    {
        public DrugInfo_ManufacturerInfoBll(IDrugInfo_ManufacturerInfoDal drugInfo_ManufacturerInfoDal)
        {
            _iBaseDal = drugInfo_ManufacturerInfoDal;
        }

       
    }
}