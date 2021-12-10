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
    public class DiagnosisInfoBll:BaseBll<DiagnosisInfo>, IDiagnosisInfoBll
    {
        public DiagnosisInfoBll(IDiagnosisInfoDal diagnosisInfoDal)
        {
            _iBaseDal = diagnosisInfoDal;
        }
    }
}