# Exercise 11-1-1 Reflection

Replace each placeholder with approximately two or three complete sentences.
Use class and method names from your completed code.

## 1. Strategy Pattern Roles

Identify the Client, Context, Strategy, and Concrete Strategies in your
completed implementation. Explain the responsibility of each role.

Write your answer here.

## 2. Shared and Variable Behavior

Which behavior remains inside `ParticipationCalculator`, and which behavior
moves into the strategy classes? Explain why the student-record filtering is
shared while the scoring algorithm varies.

Write your answer here.

## 3. Adding Another Scoring Policy

Suppose instructors request a strategy that credits only the three
highest-point events. Which new class would you add? Which existing Strategy
classes would not need to change?

Write your answer here.

## 4. The Remaining Selection

`Program.Main` still decides which strategy object to create from the
instructor's `all` or `daily` choice. Explain why that selection remains at the
application boundary even though `ParticipationCalculator` no longer contains
the scoring-rule conditional.

Write your answer here.
