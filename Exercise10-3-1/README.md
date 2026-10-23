# Exercise 10-3-1 Reflection
## 1. Factory Method Roles

Identify the Product, Concrete Products, Creator, Concrete Creators, and factory
method in your completed implementation.

The Product is `IEnrollmentSource`, and the Concrete Products are `CsvEnrollmentSource` and `CanvasApiEnrollmentSource`. 
The Creator is `EnrollmentImporter`, and the Concrete Creators are `CsvEnrollmentImporter` and `CanvasApiEnrollmentImporter`. 
The factory method is `CreateEnrollmentSource()`, which each concrete importer overrides to create its enrollment source.

## 2. Adding Another Enrollment Source

Suppose the program must import students from a database. Which new classes
would you add? Which existing Factory Method classes would not need to change?

I would add `DatabaseEnrollmentSource` implementing `IEnrollmentSource` and `DatabaseEnrollmentImporter` extending 
`EnrollmentImporter`. The new importer would override `CreateEnrollmentSource()` to return a `DatabaseEnrollmentSource`, 
so `EnrollmentImporter`, the existing concrete importers, and the existing source classes would not need to change. 
`Program.Main` would need another option to let the user select the database importer.

## 3. Simple Factory and Open/Closed

Why did adding another source require modifying
`EnrollmentSourceFactory.Create` in the Simple Factory version? How does the
Factory Method version reduce that Open/Closed Principle problem?

`EnrollmentSourceFactory.Create` needed to change because its selection logic explicitly listed the supported source types, 
so another source required another branch. In the Factory Method version, a new source can be supported by adding an 
`IEnrollmentSource` implementation and an `EnrollmentImporter` subclass that overrides `CreateEnrollmentSource()`. 
This keeps the shared `EnrollmentImporter.Import()` workflow closed to modification while allowing new source types 
through extension.

## 4. The Remaining Selection

`Program.Main` still decides which concrete importer to create. Explain why
that small selection remains at the application boundary even though the shared
`EnrollmentImporter.Import` workflow no longer selects concrete source classes.

`Program.Main` handles user input and sets up the application, so it still 
needs to choose `CsvEnrollmentImporter` or `CanvasApiEnrollmentImporter` based on the user's selection. 
After that choice, it calls `Import()` through the `EnrollmentImporter` abstraction, and the selected subclass supplies 
the source through `CreateEnrollmentSource()`. Keeping this small selection at the application boundary lets the shared 
import and validation workflow stay the same when another source is added.
