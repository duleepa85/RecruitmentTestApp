using Recruitment.Core.DomainObjects;
using Recruitment.Data.DBFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Recruitment.Data.Actions
{
    class GetWorkflowsAction : DBActionBase<List<RPWorkflow>>
    {
        protected override List<RPWorkflow> Body(DbConnection connection)
        {
            try
            {
                List<RPWorkflow> states = new List<RPWorkflow>();
                DbCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[RP_GetWorkflows]";
                var _reader = command.ExecuteReader();

                SafeDataReader reader = new SafeDataReader(_reader);
                while (reader.Read())
                {
                    RPWorkflow wf = new RPWorkflow();
                    wf.Id = reader.GetInt32("ID");
                    wf.WorkflowSequence = reader.GetString("WorkflowSequence");
                    states.Add(wf);
                }
                return states;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
