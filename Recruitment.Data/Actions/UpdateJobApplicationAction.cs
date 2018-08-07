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
            command.Parameters.Add(DataAcessUtils.CreateParam("@State", DbType.String, _application.CurrentState));
            command.ExecuteNonQuery();
            return true;
        }
    }
}
