## Collaboration
In one or two sentences, explain why the two classes directly collaborate and what information or behavior one supplies to the
other.

Equipment Catalog and Category collaborate because students browse the catalog by category, and staff organize
equipment items in the catalog by grouping those items into categories. The catalog supplies the collection of categories
to display. Each Category supplies its name, description, and standard loan period so the catalog can present that group
correctly.

## Association
Which property or collection represents the association between the two objects?

The association is EquipmentCatalog (1) lists Category (0..*). In C# it is represented by EquipmentCatalog.Categories
(List<Category>, the many side) and Category.Catalog (EquipmentCatalog, the one side). Both properties refer to the same
two objects after Program.Main connects them.

## Multiplicity
Explain the multiplicity at each end of the UML association. How are these multiplicities represented in C#?

The catalog end is 1: a category belongs to exactly one equipment catalog, stored as a single object reference
(EquipmentCatalog Catalog). The category end is 0..*: one catalog can list zero or more categories, stored as a collection
(List<Category> Categories). In the demonstration that list holds one Category named "Cameras".

## Responsibility Trace
Identify one responsibility from each class. Name the UML operation and C# method that implement that responsibility.

Equipment Catalog — CRC responsibility “Show available categories.” UML operation showAvailableCategories() : void is implemented by C# method ShowAvailableCategories().
Category — CRC responsibility “set up standard loan period.” UML operation setStandardLoanPeriod(days: int) : void is implemented by C# method SetStandardLoanPeriod(int days).
