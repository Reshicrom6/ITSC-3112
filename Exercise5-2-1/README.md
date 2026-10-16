# Assignment 5-2-1 Reflection

## 1. Why Person Is Abstract
`Person` contains the state shared by every role in the system: a unique `Id`, a `Name`, and an `Email`. It also declares the common behavior `GetRoleDescription()`, which each concrete role must provide in its own way. A generic `Person` object would be incomplete because it does not represent a real role in the application; `Student`, `Teacher`, and `InstructorAssistant` each have different responsibilities and role-specific behavior that cannot be captured by one generic type alone.

## 2. Why Administration Is an Interface
`IParticipationAdministrator` represents the ability to create and update participation records. This capability belongs to `Teacher` and `InstructorAssistant` because they are the roles that can administer participation. It does not belong to `Student` because students are not responsible for recording or editing other students' participation entries.

## 3. Person Polymorphism
In the `foreach (Person person in list)` loop, the variable `person` is typed as `Person`, but at runtime it may hold a `Student`, `Teacher`, or `InstructorAssistant`. When the code calls `person.GetRoleDescription()`, the runtime checks the actual object in memory and invokes the override on that concrete class. For example, if `person` holds a `Teacher`, the call resolves to `Teacher.GetRoleDescription()`, which returns `"Teacher"`.

## 4. Interface Polymorphism
In the `foreach (IParticipationAdministrator administrator in administrators)` loop, the variable `administrator` is typed as the interface. When code calls `administrator.RecordParticipation(...)`, the runtime dispatches to the concrete implementation stored in the list, such as `Teacher` or `InstructorAssistant`. In the current program, the record is created by the concrete object currently held in that list, such as `thayer` when the teacher is being iterated.

## 5. Extending the Design
When `InstructorAssistant` was added, the design changed by adding a new class that inherits from `Person` and implements `IParticipationAdministrator`. The existing loop bodies remained unchanged because polymorphism lets the same `foreach` code work with any object that matches the base type or interface. The repository methods also remained unchanged because they still manage `ParticipationRecord` objects through the same contracts and do not depend on whether the administrator was a `Teacher` or an `InstructorAssistant`.
