# Exercise 10-3-1 Reflection

Replace each placeholder with approximately two or three complete sentences.
Use class and method names from your completed code.

## 1. Factory Method Roles

Identify the Product, Concrete Products, Creator, Concrete Creators, and factory
method in your completed implementation.

Write your answer here.

## 2. Adding Another Enrollment Source

Suppose the program must import students from a database. Which new classes
would you add? Which existing Factory Method classes would not need to change?

Write your answer here.

## 3. Simple Factory and Open/Closed

Why did adding another source require modifying
`EnrollmentSourceFactory.Create` in the Simple Factory version? How does the
Factory Method version reduce that Open/Closed Principle problem?

Write your answer here.

## 4. The Remaining Selection

`Program.Main` still decides which concrete importer to create. Explain why
that small selection remains at the application boundary even though the shared
`EnrollmentImporter.Import` workflow no longer selects concrete source classes.

Write your answer here.
