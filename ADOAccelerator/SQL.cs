using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADOAccelerator
{
    /// <summary>
    /// 
    /// </summary>
    public class SQL
    {
        #region Constructors
        
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

        #endregion

        #region Properties
        
        public SqlConnection dataBase { get; }
        #endregion

        #region Methods
        public void Close()
        {
            dataBase.Close();
        }

        public void Connect()
        {
            dataBase.Open();
        }

        public SqlDataReader getDataReader(string request)
        {
            if (dataBase.State == ConnectionState.Open)
            {
                // Créer une commande qui sélectionne les années dans SalesOrderHeader
                SqlCommand command = dataBase.CreateCommand();
                command.CommandText = request;
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else throw new InvalidOperationException("The connection must be open to perfor this action");
        }
        #endregion
    }
}
