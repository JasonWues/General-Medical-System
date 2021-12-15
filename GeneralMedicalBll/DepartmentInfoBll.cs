using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;

namespace GeneralMedicalBll
{
    public class DepartmentInfoBll : BaseBll<DepartmentInfo>, IDepartmentInfoBll
    {
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal)
        {
            _iBaseDal = departmentInfoDal;
        }
    }
}