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
    public class BehospitalizedBll:BaseBll<Behospitalized>, IBehospitalizedBll
    {
        public BehospitalizedBll(IBehospitalizedDal behospitalizedDal)
        {
            _iBaseDal = behospitalizedDal;
        }

    }
}
