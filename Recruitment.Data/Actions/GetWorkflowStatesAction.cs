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
    class GetWorkflowStatesAction : DBActionBase<List<WFState>>
    {
        protected override List<WFState> Body(DbConnection connection)
        {
            try
            {
                List<WFState> states = new List<WFState>();
                DbCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[RP_GetWorkflowStates]";
                var _reader = command.ExecuteReader();

                SafeDataReader reader = new SafeDataReader(_reader);
                while (reader.Read())
                {
                    WFState st = new WFState();
                    st.Id = reader.GetInt32("ID");
                    st.State = reader.GetString("State");
                    states.Add(st);
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
