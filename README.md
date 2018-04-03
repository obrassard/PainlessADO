# Painless ActiveX Data Objects

![version](https://img.shields.io/badge/Version-1.3.0-brightgreen.svg?style=for-the-badge)  
![](https://img.shields.io/badge/Language-CSharp-5b0dc3.svg?style=for-the-badge)

#### [_Read the complete documentation on GitBook_](https://painlessado.obrassard.ca)

### PainlessADO is a wrapper for C\#'s ActiveX Data Objects Library \(ADO.NET\) which simplifies the use of basic SQL functions.

PainlessADO includes the **SQL** class, which allows you to quickly connect to a Microsoft SQL database and execute queries with or without parameters in your C\# code :

```csharp
public class SQL
```

Version 1.3 also includes **support for MySQL** databases which provides the same methods as the SQL class, only they have been adapted to MySQL.  Using this class is therefore exactly the same as the **SQL** class which is detailed in this document.

```csharp
public class MySQL
```

---

### Table of contents

* [Getting Started](/docs/getting-started.md)
* [Methods](/docs/methods.md)
  * [Connect](/docs/methods/connect.md)
  * [Close](/docs/methods/close.md)
  * [GetDataReader](/docs/methods/getdatareader.md)
  * [RetrieveAllData](/docs/methods/retrievealldata.md)
  * [ExecuteScalar](/docs/methods/executescalar.md)
  * [ExecuteNonQuery](/docs/methods/executenonquery.md)
* [Properties](/docs/properties.md)
  * [Database](/docs/properties/database.md)
  * [State](/docs/properties/state.md)    



