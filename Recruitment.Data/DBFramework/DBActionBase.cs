using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Recruitment.Data.DBFramework
{
    /// <summary>
    /// This class is the base class for user defined Db commands. Use of this class will ensure
    /// proper closing of the connection objects used. It is highly encouraged to use
    /// sub classes of this where ever possible.
    ///
    /// Sub classes are expected to override the Body() method and perform any database operations on top of the passed in connection object.
    /// To execute the command (which is developed as a sub class of this) users need to
    /// call the execute method of it.
    ///
    /// This particular execute method will obtain a connetion from the database,
    /// then will run the command Body and then properly close the connection.
    /// </summary>
    /// <typeparam name="T">expected return object type of this command (if any)</typeparam>
    /// <remarks></remarks>
    internal abstract class DBActionBase<T>
    {


        private DbConnection _connection;
        private DbTransaction _transaction;

        /// <summary>
        /// Implement this method and perform any required database operation by using
        /// the provided DbConnection. Implementer of this method is free from connection
        /// close hazzel and will be taken care by the 'Execute()' base method of the class.
        /// </summary>
        /// <param name="connection">Connection instance which is ready for use</param>
        /// <returns>Output of the command execution. This exact object will be
        /// returned when the Execute() method is called by the users</returns>
        /// <remarks></remarks>
        protected abstract T Body(DbConnection connection);

        /// <summary>
        /// call this method to execute this database Action class
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        internal T Execute(EnumDatabase dbName)
        {
            _connection = GenericDBFactory.GetConnection(dbName);


            ConnectionState FinallyExpected = ConnectionState.Closed; // this is the expected state at the end of the operation
            ConnectionState FinallyActual = 0;
            T ReturnInstance;

            // 'using' clause will ensure the proper clasong of the connection
            using (_connection)
            {
                try
                {
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        _connection.Open(); //open the connection
                    }
                    // check connection opened proprely
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        throw (new Exception("Problem in opening the DB Connection. Connection not opened"));
                    }
                    // run the command body of this command
                    ReturnInstance = Body(_connection);

                }
                catch (System.Exception ex) // some problem occured in executing this command
                {
                    //US.CreditorPortal.Core.DataAccess.Core.Exception.USPException exp = new US.CreditorPortal.Core.DataAccess.Core.Exception.USPException();
                    //exp.logg(ex.Message);

                    throw (new Exception("Error on data. " + ex.Message));
                }
                finally // close the connection
                {
                    if (!(_connection.State == System.Data.ConnectionState.Closed))
                    {
                        _connection.Close();
                        FinallyActual = _connection.State;
                    }
                }
            }

            if (FinallyExpected != FinallyActual)
            {
                throw (new Exception("Problem in closing the DB connection. Db connection is not properly closed"));
            }
            return ReturnInstance;
        }


        internal DbTransaction ParentTransaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }


        /// <summary>
        /// This will create a command which is assocoiated with this db Action's
        /// Connection. Make sure calls to this method happens only withing the
        /// overidden Body() method of this action
        /// </summary>
        /// <param name="type">CommandType of the new Command</param>
        /// <param name="commandText">CommandText of the new Command</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected DbCommand CreateCommand(CommandType type, string commandText)
        {
            DbCommand command = GenericDBFactory.Factory.CreateCommand();
            command.Connection = _connection;
            command.CommandText = commandText;
            command.CommandType = type;
            command.CommandTimeout = int.MaxValue;
            return command;
        }
    }
}
