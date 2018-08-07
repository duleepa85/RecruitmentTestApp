using Recruitment.Core.DomainObjects;
using Recruitment.Data.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Data
{
    public class DataManager
    {
        public static List<RPApplication> GetAllApplication()
        {
            try
            {
                GetAllApplicationsAction cmd = new GetAllApplicationsAction();
                return cmd.Execute(DBFramework.EnumDatabase.Recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<WFState> GetStates()
        {
            try
            {
                GetWorkflowStatesAction cmd = new GetWorkflowStatesAction();
                return cmd.Execute(DBFramework.EnumDatabase.Recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<RPWorkflow> GetWorkflows()
        {
            try
            {
                GetWorkflowsAction cmd = new GetWorkflowsAction();
                return cmd.Execute(DBFramework.EnumDatabase.Recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateJobApplication(RPApplication app)
        {
            try
            {
                UpdateJobApplicationAction cmd = new UpdateJobApplicationAction(app);
                return cmd.Execute(DBFramework.EnumDatabase.Recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
