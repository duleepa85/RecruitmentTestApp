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
    class GetAllApplicationsAction : DBActionBase<List<RPApplication>>
    {
        protected override List<RPApplication> Body(DbConnection connection)
        {
            try
            {
                List<RPApplication> applications = new List<RPApplication>();
                DbCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[RP_GetAllApplications]";
                var _reader = command.ExecuteReader();

                SafeDataReader reader = new SafeDataReader(_reader);
                while (reader.Read())
                {
                    RPApplication app = new RPApplication();
                    app.Id = reader.GetInt32("ApplicationId");
                    app.ApplicantName = reader.GetString("ApplicantName");
                    app.CurrentState = reader.GetString("CurrentState");
                    app.WorkflowSequence = reader.GetString("WorkflowSequence");
                    applications.Add(app);
                }
                return applications;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
