## ExectueNonQuery

```csharp
public int ExecuteNonQuery(string query)
```

_Executes a command - without parameters - that doesn't retrieve any data from the database \(e.g. _`INSERT`_, _`UPDATE`_, _`DELETE`_ ...\), and returns the numbers of rows affected._

#### Parameters :

**query** - a string that represent the sql _select_ query without parameters.

#### Return :

The numbers of rows affected by the query.

#### Throw :

**InvalidOperationException,** if the connection isn't opened.

---

```csharp
public int ExecuteNonQuery(string query, params string[] sqlParameters)
```

_Executes a command - with parameters - that doesn't retrieve any data from the database \(e.g. _`INSERT`_, _`UPDATE`_, _`DELETE`_ ...\), and returns the numbers of rows affected._

#### Parameters :

**query** - a string that represent the sql\_select\_query with parameters.  
**sqlParameters** - One to many pairs of strings, parameter's name first followed by the value. \(E.g.: "param1", "value1", "param2", "value2"...\).

> Notice : Be sure to always write pairs of strings, or it won't work.

E.g:

```csharp
sql.ExecuteNonQuery("delete from table where categoryId = @Id AND productType = @type", "id", "12", "type", "2");
```

#### Return :

The numbers of rows affected by the query.

#### Throw :

**InvalidOperationException, **if the connection isn't opened.

**ArgumentException, **if the number of parameters isn't even

