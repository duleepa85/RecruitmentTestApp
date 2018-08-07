using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Recruitment.Data.DBFramework
{
    internal class DataAcessUtils
    {
        /// <summary>
        /// Facade method for creating a DbParamter instance. 
        /// 'Direction' property of the returned param is set to "ParameterDirection.Input "
        /// </summary>
        /// <param name="paramName">value for 'DbParameter.ParameterName</param>
        /// <param name="type">value for 'DbParameter.DbType</param>
        /// <param name="value">value for 'DbParameter.Value</param>
        /// <returns>newly created DbParameter instance</returns>

        internal static DbParameter CreateParam(string paramName, DbType type, Object value)
        {
            // create the parameter
            DbParameter param = GenericDBFactory.Factory.CreateParameter();
            param.ParameterName = paramName;
            param.DbType = type;
            param.Value = value;
            return param;
        }

        internal static SqlParameter CreateParam(string paramName, SqlDbType type, Object value)
        {
            // create the parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.SqlDbType = type;
            param.Value = value;
            return param;
        }
    }
}
