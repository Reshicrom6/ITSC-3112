# Reflection

Replace each placeholder with two or three complete sentences.

### 1. Object-to-table mapping

Why is `Student.Id` defined as both TEXT and a primary key? How are optional strings
and `IsActive` represented in SQLite?

`Student.Id` is defined as both TEXT and a primary key to prevent duplicate GUID values.
Optional strings are represented just by TEXT because SQL automatically stores their value
as null if no value is presented. `IsActive` is stored as an INTEGER and enforced as NOT NULL
with a default value of 1, or true.

### 2. Commands and resources

When do you use `ExecuteNonQuery`, `ExecuteReader`, and `ExecuteScalar`?
Why do the connection, command, and reader use `using` declarations?

- `ExecuteNonQuery` is used to execute SQL without returning a result set.
- `ExecuteReader` is used to read rows.
- `ExecuteScalar` us used to retrieve a single value.\
A `using` declaration is made so that the resource is disposed of when execution leaves its
scope.

### 3. Parameters and null values
How do you translate between C# null and database NULL?

`DBNull.Value` is used to represent database NULL when a C# value is null.
`reader.IsDBNull` is used to check if a stored value is NULL so that it can be returned
as C# null instead of a string.


### 4. Persistent storage and the repository boundary

Describe what survives an application restart after your changes.
Why can the menu keep calling the same repository interface?

Student records are saved in the `app.db` file so they can still be retrieved after
the application restarts. The menu can keep calling the same repository interface
because `StudentRepositoryPersisted` implements `IStudentRepository` and provides
the same `Add` and `GetAll` methods.

