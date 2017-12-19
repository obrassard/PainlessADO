## GetDataReader

```csharp
 public SqlDataReader GetDataReader(string query)
```

_Sends a query to the database and builds a SqlDataReader \(ExecuteReader\) that can be used to get each records one at a time. _

#### Parameters :

**query** - a string that represent the sql _select_ query without parameters.

#### Return :
A `SqlDataReader` that can be used to get each records one at a time.


#### Throw :

**InvalidOperationException,** if the connection isn't opened.

---

```csharp
public SqlDataReader GetDataReader(string query, params string[] sqlParameters)
```

_Sends a query with parameters to the database and builds a SqlDataReader \(ExecuteReader\) that can be used to get each records one at a time._

#### Parameters :

**query** - a string that represent the sql\_select\_query with parameters.  
**sqlParameters** - One to many pairs of strings, parameter's name first followed by the value. \(E.g.: "param1", "value1", "param2", "value2"...\).

> Notice : Be sure to always write pairs of strings, or it won't work.

E.g:

```csharp
SqlDataReader reader = sql.GetDataReader("select * from table where id = @id", "id", "12")
```

#### Return :
A `SqlDataReader` that can be used to get each records one at a time.

#### Throw :

**InvalidOperationException, **if the connection isn't opened.

**ArgumentException, **if the number of parameters isn't even

