using System;
using System.Data;
using System.Data.SqlClient;

namespace PainlessADO
{
    /// <summary>
    /// Wrapper for C#'s ActiveX Data Objects Library (ADO.NET) which simplify the use of basics SQL functions.
    /// </summary>
    public class SQL
    {

        #region Error Messages
        private const string ER_NOT_OPENED_CONNECTION = "The connection must be opened to perform this action";
        #endregion

        #region Properties
        public SqlConnection dataBase { get; }
        #endregion

        #region Constructors
        //=================================================================================================

        /// <summary>
        /// Create new sql connection and open this connection with user name and password
        /// </summary>
        /// <param name="serverSource">Server's location</param>
        /// <param name="dataBaseName">Data base's name</param>
        /// <param name="userID">User's login id</param>
        /// <param name="password">User's password</param>
        public SQL(string serverSource, string dataBaseName, string userID, string password )
        {

            string connectionString = "Data Source=" + serverSource + ";Initial Catalog=" + dataBaseName + "; User ID=" + userID + "; Pwd=" + password;
            dataBase = new SqlConnection(connectionString);
            Connect();
        }

        //=================================================================================================

        /// <summary>
        /// Create new sql connection and open this connection, using Itegrated Security
        /// </summary>
        /// <param name="serverSource">Server's location</param>
        /// <param name="dataBaseName">Data base's name</param>
        /// <param name="useIntegratedSecurity">Shoul'd be true to use Integrated Security</param>
        public SQL(string serverSource, string dataBaseName, bool useIntegratedSecurity)
        {
            string connectionString = "Data Source=" + serverSource + ";Initial Catalog=" + dataBaseName + ";Integrated Security=" + useIntegratedSecurity;
            dataBase = new SqlConnection(connectionString);
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
            dataBase.Close();
        }

        //=================================================================================================

        /// <summary>
        /// Open a connection to the server
        /// </summary>
        public void Connect()
        {
            dataBase.Open();
        }

        //=================================================================================================

        /// <summary>
        /// Sends the query to the Connection and builds a SqlDataReader. (ExecuteReader)
        /// </summary>
        /// <param name="query">sql query</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader GetDataReader(string query)
        {
            if (dataBase.State == ConnectionState.Open)
            {
                SqlCommand command = dataBase.CreateCommand();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================

        /// <summary>
        /// Sends the query to the Connection and builds a SqlDataReader. (ExecuteReader)
        /// </summary>
        /// <param name="query">sql query</param>
        /// <param name="sqlParameters">One to many string combining a parameter name and a value (Example: "ParamName:Value")</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader GetDataReader(string query, params string[] sqlParameters)
        {
            if (dataBase.State == ConnectionState.Open)
            {
                SqlCommand command = CreateCommandWthParams(query, sqlParameters);            
                SqlDataReader reader = command.ExecuteReader();
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
            SqlDataReader reader = GetDataReader(query);
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
        /// <param name="sqlParameters">One to many string combining a parameter name and a value (Example: "ParamName:Value")</param>
        /// <returns>DataTable</returns>
        public DataTable RetrieveAllData(string query, params string[] sqlParameters)
        {
            
            SqlDataReader reader = GetDataReader(query, sqlParameters);
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
            if (dataBase.State == ConnectionState.Open)
            {

                SqlCommand commande = dataBase.CreateCommand();
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
        /// <param name="sqlParameters">One to many string combining a parameter name and a value (Example: "ParamName:Value")</param>
        /// <returns>A castable object</returns>
        public object ExecuteScalar(string query, params string[] sqlParameters)
        {
            if (dataBase.State == ConnectionState.Open)
            {
                SqlCommand command = CreateCommandWthParams(query, sqlParameters);
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
            if (dataBase.State == ConnectionState.Open)
            {

                SqlCommand commande = dataBase.CreateCommand();
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
        /// <param name="sqlParameters">One to many string combining a parameter name and a value (Example: "ParamName:Value")</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string query, params string[] sqlParameters)
        {
            if (dataBase.State == ConnectionState.Open)
            {
                SqlCommand commande = CreateCommandWthParams(query, sqlParameters);
                return commande.ExecuteNonQuery();
            }
            else throw new InvalidOperationException(ER_NOT_OPENED_CONNECTION);
        }

        //=================================================================================================
        #endregion

        #region Private Methods
        private SqlCommand CreateCommandWthParams(string query, string[] sqlParameters)
        {
            SqlCommand command = dataBase.CreateCommand();
            command.CommandText = query;

            foreach (string combinedparam in sqlParameters)
            {
                string[] separatedParams = combinedparam.Split(':');
                if (separatedParams.Length != 2) throw new ArgumentException("Parameter's syntax is incorect... Use \"ParamName:Value\"");
                string name = separatedParams[0];
                string value = separatedParams[1];

                SqlParameter param = new SqlParameter(name, value);
                command.Parameters.Add(param);
            }

            return command;
        }
        #endregion
    }
}
