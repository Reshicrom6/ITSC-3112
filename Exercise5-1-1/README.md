# Exercise 5-1-1 Reflection

Replace each `Write your answer here.` line with a concise response that cites specific classes, members, or runtime results from your final project.

## 1. Base Contract and Member Ownership

State the contract promised by the starter `CampusSpace`. Identify which members belong to every campus space and which members belong only to reservable spaces.

The starter `CampusSpace` contract represents members that apply to every campus space, specifically identity and shared state like `SpaceCode` and `Name` (and the base construction rules that require valid values). Reservation behavior is not universal, so members such as `Reserve()`, `Release()`, `IsReserved`, and `GetMaximumReservationHours()` belong in `ReservableSpace`, not in `CampusSpace`. In the corrected design, `DisplayGallery` remains a valid `CampusSpace` without being forced to implement reservation behavior it does not support.

## 2. Method-Level and Hierarchy-Level Substitutability

Explain why returning zero hours violates the base result guarantee. Then explain why changing the override to return one hour still does not make `DisplayGallery` a valid reservable subtype.

Returning `0` from `GetMaximumReservationHours()` violates the result guarantee that reservable spaces return at least one hour. Any caller using the base reservation contract can reasonably depend on a positive duration, so `0` breaks method-level substitutability. Changing an override to return `1` fixes only that method result, but it still does not make `DisplayGallery` a valid reservable subtype because hierarchy-level substitutability requires the full reservable behavior contract (`Reserve`, `Release`, reservable state transitions, and reservation policy semantics), which a gallery does not model in this domain.

## 3. Composition and Change Boundaries

Explain why the maximum reservation duration is represented with an `IReservationPolicy` collaborator instead of another subtype override. Describe one policy change that can occur without modifying `StudyRoom` or `ComputerLab`.

Maximum reservation duration is delegated to an `IReservationPolicy` collaborator so rule changes are isolated from space type inheritance. `ReservableSpace.GetMaximumReservationHours()` now retrieves the value from its stored policy object, keeping policy variation compositional instead of forcing subtype overrides for each rule variant. For example, changing a lab from a fixed 4-hour policy to a stricter fixed 2-hour policy only swaps the policy instance (`FixedReservationPolicy(2)`) and does not require modifying `StudyRoom` or `ComputerLab` classes.

## 4. Base-Type Test

Describe how the final `List<ReservableSpace>` in Program.cs better enforces the domain invariants.

Using `List<ReservableSpace>` in `Program.cs` enforces invariants at compile time: only types that actually support reservation operations can be added. This prevents non-reservable types like `DisplayGallery` from entering a collection that is iterated with reservation calls (`GetMaximumReservationHours()`, `Reserve()`, `Release()`). The result is a safer loop with no runtime subtype checks, casts, or branch logic to guard invalid members.