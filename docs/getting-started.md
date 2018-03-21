# Getting Started

## Download PainlessADO:

You can either download the [compiled dll library](https://github.com/obrassard/PainlessADO/releases) or the source code from the [github repo](https://github.com/obrassard/PainlessADO).

## Connect to a database

It's easy to use **Painless ADO's SQL** class to create a new SQL connection toward a microsoft sql database. All you have to do is to create a new `SQL` object.

There are two ways to open a connection. In both cases you'll need the `serverUrl`  and the `dataBaseName`.

You can either use an user name and a password :

```csharp
public SQL(string serverUrl, string dataBaseName, string userID, string password )
```

or if you do not specify any credentials,  the connection will attempt to use **Windows Integrated Security **:

```csharp
public SQL(string serverUrl, string dataBaseName)
```

> At its creation, the SQL object create a new `SqlConnection` and try to connect to the specified database. If the server isn't available or the authentification credentials aren't valid, it will throw an `SqlException`.

From version 1.3 you can also create a new MySQL connection toward a MySQL database. For that you must use a `MySQL` object. **Note that using this class is exactly the same as the SQL class.**

```csharp
public MySQL(string serverAddress, string dataBaseName, string userID, string password )
```





