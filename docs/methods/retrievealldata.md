## RetrieveAllData

```csharp
public DataTable RetrieveAllData(string query)
```

_Execute a query without parameters and return all data in a DataTable that can be use as a datasource for a _`DataGridView`_._

#### Parameters :

**query** - a string that represent the sql _select_ query without parameters.

#### Return :
A `DataTable` that can be use as a datasource for a `DataGridView`.

---

```csharp
public DataTable RetrieveAllData(string query, params string[] sqlParameters)
```

_Execute a query with parameters and return all data in a DataTable that can be use as a datasource for a _`DataGridView`_._

#### Parameters :

**query** - a string that represent the sql\_select\_query with parameters.  
**sqlParameters** - One to many pairs of strings, parameter's name first followed by the value. \(E.g.: "param1", "value1", "param2", "value2"...\).

> Notice : Be sure to always write pairs of strings, or it won't work.

E.g:

```csharp
ProductsDataGrid.DataSource = RetrieveAllData("select * from table where id = @id", "id", "12")
```

#### Return :
A `DataTable` that can be use as a datasource for a `DataGridView`.

#### Throw :

**ArgumentException, **if the number of parameters isn't even.

