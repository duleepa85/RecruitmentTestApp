using Recruitment.Core.DomainObjects;
using Recruitment.Data;
using Recruitment.Data.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.BusinessLogic
{
    public class RecruitmentManager
    {
        public static List<RPApplication> GetAllApplications()
        {
           return DataManager.GetAllApplication();
        }

        public static List<WFState> GetStates()
        {
            return DataManager.GetStates();
        }

        public static List<RPWorkflow> GetWorkflows()
        {
            return DataManager.GetWorkflows();
        }

        public static bool UpdateJobApplication(RPApplication app)
        {
            return DataManager.UpdateJobApplication(app);
        }
    }
}
