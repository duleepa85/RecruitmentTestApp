using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.DomainObjects
{
   public class Interview
    {
        public int ID { get; set; }

        public InterviewType Interviewtype { get; set; }

        public Cadidate Candidate { get; set; }
    }

    public enum InterviewType
    {
        Technical,
        HR
    }
}
