﻿using PTFiles.Application.Common.Models;
using System.Collections.Generic;

namespace PTFiles.Application.Features.Patients.GetPatient
{
    public class GetPatientVm : PersonVm
    {
        public string Occupation { get; set; }
        public IReadOnlyCollection<PatientCaseFileVm> CaseFiles { get; set; }
    }

    public class PatientCaseFileVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}