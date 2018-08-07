﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.DomainObjects
{
    public class RPApplication
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string CurrentState { get; set; }
        public int WorkflowId { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
}
