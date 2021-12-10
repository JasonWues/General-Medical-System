using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalBll
{
    public class DrugInfo_ManufacturerInfoBll:BaseBll<DrugInfo_ManufacturerInfo>, IDrugInfo_ManufacturerInfoBll
    {
        public DrugInfo_ManufacturerInfoBll(IDrugInfo_ManufacturerInfoDal drugInfo_ManufacturerInfoDal)
        {
            _iBaseDal= drugInfo_ManufacturerInfoDal;
        }
    }
}
