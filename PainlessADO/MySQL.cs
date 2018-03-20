using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PainlessADO
{
    /// <summary>
    ///  Wrapper for C#'s ActiveX Data Objects Library (ADO.NET) which simplify the use of basics MySQL functions.
    ///  This class can be use to connect to a MySql Database 
    ///  Tis class require the MySql.Data package: https://www.nuget.org/packages/MySql.Data/
    /// </summary>
    public class MySQL
    {

        #region Error Messages
        private const string ER_NOT_OPENED_CONNECTION = "The connection must be opened to perform this action";
        #endregion


        #region Properties
        /// <summary>
        /// Return the data base's SqlConnection object
        /// </summary>
        public MySqlConnection DataBase { get; }

        /// <summary>
        /// Return the data base's connection state
        /// </summary>
        public ConnectionState State { get { return DataBase.State; } }
        #endregion

        #region Constructors
        //=================================================================================================

        /// <summary>
        /// Create new sql connection and open this connection with user name and password
        /// </summary>
        /// <param name="serverAddress">Server's location</param>
        /// <param name="dataBaseName">Data base's name</param>
        /// <param name="userID">User's login id</param>
        /// <param name="password">User's password</param>
        public MySQL(string serverAddress, string dataBaseName, string userID, string password )
        {
            string connectionString = "server = "+serverAddress+"; uid = "+userID+"; pwd = "+password+"; database = "+dataBaseName;
            DataBase = new MySqlConnection(connectionString);
            Connect();
        }

 
        //=================================================================================================

        #endregion

        #region SQL Methods
        //=================================================================================================

        /// <summary>
        /// Closes an open database connection
        /// </summary>
        public void Close()
        {
            DataBase.Close();
        }

        //=================================================================================================

        /// <summary>
        /// Open a connection to the server
        /// </summary>
        public void Connect()
        {
            DataBase.Open();
        }

        //=================================================================================================

        /// <summary>
        /// Sends the query to the Connection and builds a SqlDataReader. (ExecuteReader)
        /// </summary>
        /// <param name="query">sql query</param>
        /// <returns>SqlDataReader</returns>
        public MySqlDataReader GetDataReader(string query)
        {
            if (DataBase.State == ConnectionState.Open)
            {
                MySqlCommand command = DataBase.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Sends the query to the Connection and builds a SqlDataReader. (ExecuteReader)
        /// </summary>
        /// <param name="query">sql query</param>
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first followed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>SqlDataReader</returns>
        public MySqlDataReader GetDataReader(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
            {
                MySqlCommand command = CreateCommandWthParams(query, sqlParameters);
                MySqlDataReader reader = command.ExecuteReader();
                return reader;

            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Get all data from query in a DataTable
        /// </summary>
        /// <param name="query">sql query</param>
        /// <returns>DataTable</returns>
        public DataTable RetrieveAllData(string query)
        {
            MySqlDataReader reader = GetDataReader(query);
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            return table;
        }

        //=================================================================================================

        /// <summary>
        /// Get all data from query in a DataTable 
        /// </summary>
        /// <param name="query">sql query</param>
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first followed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>DataTable</returns>
        public DataTable RetrieveAllData(string query, params string[] sqlParameters)
        {
            
            MySqlDataReader reader = GetDataReader(query, sqlParameters);
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            return table;
        }
       
        //=================================================================================================

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. 
        /// Additional columns or rows are ignored 
        /// </summary>
        /// <param name="query">sql query</param>
        /// <returns>A castable object</returns>
        public object ExecuteScalar(string query)
        {
            if (DataBase.State == ConnectionState.Open)
            {

                MySqlCommand commande = DataBase.CreateCommand();
                commande.CommandText = query;

                return commande.ExecuteScalar();

            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. 
        /// Additional columns or rows are ignored 
        /// </summary>
        /// <param name="query">sql query</param>
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first followed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>A castable object</returns>
        public object ExecuteScalar(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
            {
                MySqlCommand command = CreateCommandWthParams(query, sqlParameters);
                return command.ExecuteScalar();
            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected
        /// </summary>
        /// <param name="query"></param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string query)
        {
            if (DataBase.State == ConnectionState.Open)
            {

                MySqlCommand commande = DataBase.CreateCommand();
                commande.CommandText = query;

                return commande.ExecuteNonQuery();

            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected
        /// </summary>
        /// <param name="query">sql query</param>
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first followed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
            {
                MySqlCommand commande = CreateCommandWthParams(query, sqlParameters);
                return commande.ExecuteNonQuery();
            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================
        #endregion

        #region Private Methods
        private MySqlCommand CreateCommandWthParams(string query, string[] sqlParameters)
        {
            MySqlCommand command = DataBase.CreateCommand();
            command.CommandText = query;

            if (sqlParameters.Length % 2 != 0) throw new ArgumentException("The numbers of parameters must be even. Write every parametters, followed by their value");

            for (int pairIndex = 0; pairIndex < sqlParameters.Length; pairIndex += 2)
            {
                string name = sqlParameters[pairIndex];
                string value = sqlParameters[pairIndex+1];

                MySqlParameter param = new MySqlParameter(name, value);
                command.Parameters.Add(param);
            }

            return command;
        }
        #endregion
    }
}
