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
    class UpdateJobApplicationAction : DBActionBase<bool>
    {
        private RPApplication _application = null;
        public UpdateJobApplicationAction(RPApplication app)
        {
            this._application = app;
        }

        protected override bool Body(DbConnection connection)
        {
            DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[RP_UpdateJobApplication]";
            command.Parameters.Add(DataAcessUtils.CreateParam("@ApplicationId", DbType.Int32, _application.Id));
            command.Parameters.Add(DataAcessUtils.CreateParam("@CandidateId", DbType.Int32, _application.ApplicantId));
            command.Parameters.Add(DataAcessUtils.CreateParam("@CandidateName", DbType.String, _application.ApplicantName));
            command.Parameters.Add(DataAcessUtils.CreateParam("@State", DbType.String, _application.CurrentState));
            command.Parameters.Add(DataAcessUtils.CreateParam("@WorkflowId", DbType.Int32, _application.WorkflowId));
            DbParameter para1 = new SqlParameter();
            para1.DbType = DbType.Int32;
            para1.ParameterName = "@outPutID";
            para1.Direction = ParameterDirection.Output;
            command.Parameters.Add(para1);
            command.ExecuteNonQuery();
            int result = Convert.ToInt32(para1.Value);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
