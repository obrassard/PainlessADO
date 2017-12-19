## State

```csharp
public ConnectionState State { get; }
```

_Get the _`ConnectionState`_ of the database. It allows you to verify if the connection is open or not._

##### Possible values  \( `public enum ConnectionState` \)

| **Value** | **Description** |
| --- | --- |
| Broken | The connection to the data source is broken. This can occuronly after the connection has been opened. A connection in this state may be closed and then re-opened. |
| Closed | The connection is closed. |
| Connecting | The connection object is connecting to the data source. |
| Executing | The connection object is executing a command. |
| Fetching | The connection object is retrieving data. |
| Open | The connection is open. |



