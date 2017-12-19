## ExectueScalar

```csharp
public object ExecuteScalar(string query)
```

_Executes a query without parameters, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored._

#### Parameters :

**query** - a string that represent the sql _select_ query without parameters.

#### Return :
A castable `object` that represent the first column of the first row in the result set returned by the query
> You will probably need to cast the object before use.


#### Throw :

**InvalidOperationException,** if the connection isn't opened.

---

```csharp
public object ExecuteScalar(string query, params string[] sqlParameters)
```

_Executes a query with parameters, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored._


#### Parameters :

**query** - a string that represent the sql\_select\_query with parameters.  
**sqlParameters** - One to many pairs of strings, parameter's name first followed by the value. \(E.g.: "param1", "value1", "param2", "value2"...\).

> Notice : Be sure to always write pairs of strings, or it won't work.

E.g:

```csharp
string ProductName = (string)sql.ExecuteScalar("select Name from table where id = @id", "id", "12")
```

#### Return :
A castable `object` that represent the first column of the first row in the result set returned by the query
> You will probably need to cast the object before use.


#### Throw :

**InvalidOperationException, **if the connection isn't opened.

**ArgumentException, **if the number of parameters isn't even

