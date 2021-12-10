﻿using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralMedicalBll
{
    public class DepartmentInfoBll:BaseBll<DepartmentInfo>, IDepartmentInfoBll
    {
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal)
        {
            _iBaseDal = departmentInfoDal;
        }
    }
}