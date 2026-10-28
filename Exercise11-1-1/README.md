# Exercise 11-1-1 Reflection

Replace each placeholder with approximately two or three complete sentences.
Use class and method names from your completed code.

## 1. Strategy Pattern Roles

Identify the Client, Context, Strategy, and Concrete Strategies in your
completed implementation. Explain the responsibility of each role.

`Program.Main` is the Client because it selects a scoring strategy and passes it to the Context, `ParticipationCalculator`, which filters the student's records and delegates scoring. `IParticipationScoringStrategy` is the Strategy interface and defines the `Calculate` method. The Concrete Strategies are `AllEventsScoringStrategy`, which credits every event, and `DailyCategoryScoringStrategy`, which credits the first event in each category on each UTC day.

## 2. Shared and Variable Behavior

Which behavior remains inside `ParticipationCalculator`, and which behavior
moves into the strategy classes? Explain why the student-record filtering is
shared while the scoring algorithm varies.

`ParticipationCalculator.Calculate` keeps the filtering that selects records whose student's `CanvasId` matches the requested student. The strategies handle the variable scoring behavior: adding all event points or crediting only one event per category per UTC day. Filtering is shared because every scoring policy must receive only the requested student's records, regardless of how it calculates points.

## 3. Adding Another Scoring Policy

Suppose instructors request a strategy that credits only the three
highest-point events. Which new class would you add? Which existing Strategy
classes would not need to change?

I would add a `TopThreeEventsScoringStrategy` class that implements `IParticipationScoringStrategy` and whose `Calculate` method sums the three highest-point events, or all available events if there are fewer than three. Neither `AllEventsScoringStrategy` nor `DailyCategoryScoringStrategy` would need to change, and `ParticipationCalculator` could use the new strategy without modification. `Program.Main` would need another selection option to let the instructor choose the new policy.

## 4. The Remaining Selection

`Program.Main` still decides which strategy object to create from the
instructor's `all` or `daily` choice. Explain why that selection remains at the
application boundary even though `ParticipationCalculator` no longer contains
the scoring-rule conditional.

`Program.Main` handles the instructor's input, so it selects the appropriate strategy at the application boundary and passes it into `ParticipationCalculator` through its constructor. The calculator depends only on `IParticipationScoringStrategy` and calls its `Calculate` method without knowing which scoring policy was selected. This keeps input handling and object creation separate from the shared calculation workflow.
