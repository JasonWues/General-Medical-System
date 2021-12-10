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
    public class ManufacturerInfoBll:BaseBll<ManufacturerInfo>, IManufacturerInfoBll
    {
        public ManufacturerInfoBll(IManufacturerInfoDal manufacturerInfoDal)
        {
            _iBaseDal= manufacturerInfoDal;
        }
    }
}
