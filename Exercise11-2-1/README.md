# Exercise 11-2-1 Reflection

Replace each placeholder with approximately two or three complete sentences.
Use class and method names from your completed code.

## 1. Adapter Pattern Roles

Identify the Client, Target, Adaptee, and Adapter in your completed
implementation. Explain the responsibility of each role.

- Client:`EnrollmentImporter`
  - use the target without knowing the external response details.
- Target:`IEnrollmentSource`
  - defines `List<Student> GetStudents()`.
- Adaptee:`SimulatedCanvasClient`
  - returns the external `CanvasStudentResponse` shape.
- Adapter:`CanvasApiAdapter`
  - wraps the client and converts responses into `Student` objects.

## 2. Translating External Data

Describe how `CanvasApiAdapter` converts a `CanvasStudentResponse` into a
`Student`. Include the properties and any type conversion involved.

`CanvasApiAdapter` converts a `CanvasStudentResponse` into a `Student` by calling the adaptees `.GetStudents()` method.
It then iterates through the list, reading the `Student.Id` and `Student.Name` properties, and creates new `Student` objects with them,
and adds them to a list. After reading through the full list, it returns the new list of `Student` objects.


## 3. Why CSV Does Not Need an Adapter

Explain why `CsvEnrollmentSource` can implement `IEnrollmentSource` directly
while `SimulatedCanvasClient` needs an adapter.

`CsvEnrollmentSource` is able to directly return a list of the applications `Student` objects after parsing the CSV. 
`SimulatedCanvasClient` returns `CanvasStudentResponse` objects, and the data shapes of `CanvasStudentResponse` don't match the 
required data shapes of `IEnrollmentSource`, therefore, it needs an adapter.

## 4. A Future Canvas API Change

Imagine that a future Canvas client replaces `GetStudents()` with
`FetchUsers()` and returns objects containing `UserKey`, `FirstName`, and
`LastName`. What would need to change? Which application classes could remain
unchanged because of the Adapter pattern?

`CanvasApiAdapter` would call `_client.FetchUsers()` instead of `_client.GetStudents()`. It could then convert `UserKey` into the
string objects used for `Student.CanvasId`, and combine `FirstName` and `LastName` into `StudentName`. The adapter would still return
a `List<Student>` through `IEnrollmentSource.GetStudents()`. This would leave `EnrollmentImporter`, `Student`, `Program`, 
`CsvEnrollmentSource`, and `ParticipationCalculator` could remain unchanged because they do not depend on the external API’s method 
or property names.
