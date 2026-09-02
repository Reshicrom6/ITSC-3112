# Exercise 3-1-1 Reflection

## 1. Rule Ownership
Program.cs owns interaction, not domain rules. It prompts for first name, last name, ID, email, action number, and an update value, then prints the record. It should not decide what a valid ID looks like, what an action is worth, or whether a point total is legal. Those facts are not UI knowledge.

Student owns identity rules: non-empty first/last name, 9-character ID, ID starts with 800, ID is numeric, email ends with @charlotte.edu. Only Student has those fields and the authority to refuse construction if they fail. After a successful constructor call, the object is a usable student.

StudentParticipation owns participation rules: non-null student, action choice in 1..4, the mapping from choice to ActionName + MaximumPoints, PointsEarned starting at 0, and UpdatePoints staying in [0, MaximumPoints]. Max points belong here because they depend on the action stored on this object. Program.cs only displays those maxima; it must not calculate or pass them in.
## 2. Student Invariants
- FirstName is not null, empty, or whitespace.
- LastName is not null, empty, or whitespace.
- StudentId has length exactly 9.
- StudentId starts with "800".

The get-only properties keep those invariants from being overwritten after construction.
## 3. StudentParticipation Invariants
- StudentInfo is not null.\
- ActionName is one of the four mapped actions, never empty/unsupported.
- MaximumPoints is the max that belongs to that same action (not an independent input).
- PointsEarned is in [0, MaximumPoints].
- Immediately after construction, PointsEarned == 0.

Relationship: ActionName and MaximumPoints are a pair from the same mapping. PointsEarned is bounded by that pair’s max. Changing the action is not allowed after construction; only points may change, and only through UpdatePoints.

## 4. Constructor Protection
- Program.cs reads the ID as a string and passes it into new Student(...).
- First/last name and email checks run first (assume they pass for this trace).
- studentId.Length != 9 - "700123456" has length 9, so this check passes.
- studentId.StartsWith("800") - it starts with "700", so this check fails and throws ArgumentException("Student id must start with '800'").
- Numeric and email checks never run.
- The assignments FirstName = ... never execute.

No usable Student is created. The exception leaves Main unless a caller catches it, so StudentParticipation is never constructed either.
## 5. Invalid State Transition
- Caller invokes UpdatePoints(6).
- Guard: newPoints < 0 || newPoints > MaximumPoints → 6 > 5 is true.
- Method throws ArgumentOutOfRangeException(nameof(newPoints)).
- PointsEarned = newPoints is never reached.

PointsEarned stays 4. The object does not accept a transition into an illegal score. That is why the assignment is not a public field or a public setter: the only legal mutation path enforces the cap.

## 6. Public-Interface Audit
A public PointsEarned setter would let any caller write, for example:

participation.PointsEarned = 99;\
participation.PointsEarned = -1;

That bypasses UpdatePoints and can break 0 <= PointsEarned <= MaximumPoints without going through the constructor or the helper mapping.

The current interface does not have that gap: PointsEarned is { get; private set; }, so only members of StudentParticipation can assign it. External code must use UpdatePoints, which rejects values outside [0, MaximumPoints].
