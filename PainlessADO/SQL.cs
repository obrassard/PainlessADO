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

        /// <summary>
        /// Return the data base's SqlConnection object
        /// </summary>
        #region Properties
        public SqlConnection DataBase { get; }

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
        /// <param name="serverSource">Server's location</param>
        /// <param name="dataBaseName">Data base's name</param>
        /// <param name="userID">User's login id</param>
        /// <param name="password">User's password</param>
        public SQL(string serverSource, string dataBaseName, string userID, string password )
        {

            string connectionString = "Data Source=" + serverSource + ";Initial Catalog=" + dataBaseName + "; User ID=" + userID + "; Pwd=" + password;
            DataBase = new SqlConnection(connectionString);
            Connect();
        }

        //=================================================================================================

        /// <summary>
        /// Create new sql connection and open this connection, using Itegrated Security
        /// </summary>
        /// <param name="serverSource">Server's location</param>
        /// <param name="dataBaseName">Data base's name</param>
        public SQL(string serverSource, string dataBaseName)
        {
            string connectionString = "Data Source=" + serverSource + ";Initial Catalog=" + dataBaseName + ";Integrated Security=true";
            DataBase = new SqlConnection(connectionString);
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
        public SqlDataReader GetDataReader(string query)
        {
            if (DataBase.State == ConnectionState.Open)
            {
                SqlCommand command = DataBase.CreateCommand();
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
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first folowed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader GetDataReader(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
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
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first folowed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
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
            if (DataBase.State == ConnectionState.Open)
            {

                SqlCommand commande = DataBase.CreateCommand();
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
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first folowed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>A castable object</returns>
        public object ExecuteScalar(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
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
            if (DataBase.State == ConnectionState.Open)
            {

                SqlCommand commande = DataBase.CreateCommand();
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
        /// <param name="sqlParameters">One to many pairs of strings, parameter's name first folowed by the value. (E.g.: "param1", "value1", "param2", "value2"...)</param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string query, params string[] sqlParameters)
        {
            if (DataBase.State == ConnectionState.Open)
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
            SqlCommand command = DataBase.CreateCommand();
            command.CommandText = query;

            if (sqlParameters.Length % 2 != 0) throw new ArgumentException("The numbers of parameters must be even. Write every parametters, folowed by their value");

            for (int pairIndex = 0; pairIndex < sqlParameters.Length; pairIndex += 2)
            {
                string name = sqlParameters[pairIndex];
                string value = sqlParameters[pairIndex+1];

                SqlParameter param = new SqlParameter(name, value);
                command.Parameters.Add(param);
            }


            return command;
        }
        #endregion
    }
}
