using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.DomainObjects
{
    public class RPApplication
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public string CurrentState { get; set; }
        public int WorkflowId { get; set; }
    }
}
