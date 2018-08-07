
using Recruitment.Core.Config;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;


namespace Recruitment.Data.DBFramework
{
    /// <summary>
    /// This class will hide the Db specific functionality and provide Db resources
    /// through common db interfaces as defined under ADO.NET Common Factory Model.
    /// </summary>
    /// <remarks></remarks>
    internal class GenericDBFactory
    {


        /// <summary>
        /// This specifies ADO.NET 2.0 framework to use specified provider classes
        /// to provide requesting database resources
        /// </summary>
        protected const string ProviderInvarientName = "System.Data.SqlClient";


        /// <summary>
        /// Returns the appropriate factory as specified in 'ProviderInvarientName'
        /// to get the database resources. To create Db resources as Commands and Parameters
        /// with generic interface, one should use this Factory.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        internal static DbProviderFactory Factory
        {
            get
            {
                return SqlClientFactory.Instance;
            }
        }

        /// <summary>
        /// To get a new Db connection call this method. Returned connection is not yet opened.
        /// Please make sure that you open it before use and then close it after.
        /// </summary>
        /// <returns>new database connection</returns>
        /// <remarks></remarks>
        internal static DbConnection GetConnection(EnumDatabase dbName)
        {

            string ConnectionString = "";

            if (dbName == EnumDatabase.Recruitment)
            {
                //ConnectionString = "server =USBOXSQL;uid = sa;pwd =box@sql787;database = Recruitment;Connection Timeout=120" providerName = "System.Data.SqlClient";
                ConnectionString = AppSettings.ConnectionString; //"Server= UNICORNDKALP;Integrated Security=True;Database= Recruitment";
                //ConnectionString = ConfigurationManager.ConnectionStrings["Recruitment"].ConnectionString;
          

            }

            DbConnection Connection = Factory.CreateConnection();
            Connection.ConnectionString = ConnectionString;

            return Connection;
        }




    }
}
