# Exercise 1-2-1 Reflection
## What is the name of the class definition used in this exercise?
Accumulator

## What is the name of the object variable used in Program.cs?
accumulator

## What is the name of the field used in Accumulator?
_total

## What is the name of the property used in Accumulator?
Total

## What is the name of the constructor that initializes the object?
Accumulator

## What is the name of the method that changes the total?
Add

## What starting state does the constructor establish?
It initializes the total to 0 (sets _total = 0), establishing a zero starting state.

## How does Add(5) change the object?
It increases the object's total by 5 (adds 5 to _total).

## Why can Program.cs read Total but not access _total directly?
Total is a public property, allowing it to be accessed outside the class, but _total is private and can only be accessed by its individual accumulator object instance.
## Which of the four Object Oriented Principles did we practice and how?
Encapsulation: the field _total is kept private and the class exposes a public property and method to access/modify the state, hiding implementation details.
