## Methods Overview

PainlessADO currently includes the **SQL** class, which simplify the use of basics SQL functions. It allows you to quickly connect to a sql database and execute queries with or without parameters in your C\# code.

| **Methods and descriptions** | **Return Type** |
| :---: | :---: |
| [SQL](/docs/getting-started.md)(string serverSource, string dataBaseName, string userID, string password)<br>*Create new sql connection and open this connection, using Integrated Security* | - |
| [SQL](/docs/getting-started.md)(string serverSource, string dataBaseName)<br>*Create new sql connection and open this connection with user name and password* | - |
| [Connect](/docs/methods/connect.md)()<br>_Opens a connection to the server_ | void |
| [Close](/docs/methods/close.md)()<br>_Closes an open connection_ | void |
| [GetDataReader](/docs/methods/getdatareader.md)(string query)<br>_Sends a query to the database and builds a SqlDataReader that can be used to get each records one at a time_ | DataReader |
| [GetDataReader](/docs/methods/getdatareader.md)(string query, params string[] sqlParameters)<br>_Sends a query with parameters to the database and builds a SqlDataReader _ | DataReader |
| [RetrieveAllData](/docs/methods/retrievealldata.md)(string query)<br>_Execute a query without parameters and return all data in a DataTable. _ | DataTable |
| [RetrieveAllData](/docs/methods/retrievealldata.md)(string query, params string[] sqlParameters)<br>_Execute a query with parameters and return all data in a DataTable. _ | DataTable |
| [ExecuteScalar](/docs/methods/executescalar.md)(string query)<br>_Execute a query without parameters and return all data in a DataTable._|Object|
| [ExecuteScalar](/docs/methods/executescalar.md)(string query, params string[] sqlParameters)<br>_Execute a query with parameters and return all data in a DataTable._|Object|
| [ExecuteNonQuery](/docs/methods/executenonquery.md)(string query)<br>_Executes a command - without parameters - that doesn't retrieve any data from the database._|int|
| [ExecuteNonQuery](/docs/methods/executenonquery.md)(string query, params string[] sqlParameters)<br>_Executes a command - with parameters - that doesn't retrieve any data from the database._|int|

