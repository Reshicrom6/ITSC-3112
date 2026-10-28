# Exercise 11-2-1 Reflection

Replace each placeholder with approximately two or three complete sentences.
Use class and method names from your completed code.

## 1. Adapter Pattern Roles

Identify the Client, Target, Adaptee, and Adapter in your completed
implementation. Explain the responsibility of each role.

Write your answer here.

## 2. Translating External Data

Describe how `CanvasApiAdapter` converts a `CanvasStudentResponse` into a
`Student`. Include the properties and any type conversion involved.

Write your answer here.

## 3. Why CSV Does Not Need an Adapter

Explain why `CsvEnrollmentSource` can implement `IEnrollmentSource` directly
while `SimulatedCanvasClient` needs an adapter.

Write your answer here.

## 4. A Future Canvas API Change

Imagine that a future Canvas client replaces `GetStudents()` with
`FetchUsers()` and returns objects containing `UserKey`, `FirstName`, and
`LastName`. What would need to change? Which application classes could remain
unchanged because of the Adapter pattern?

Write your answer here.
