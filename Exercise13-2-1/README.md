# Exercise13-2-1 Reflection

Replace each answer placeholder with at least two or three complete sentences.
Use fictional data and do not include sensitive information.

## 1. Singleton identity and lifetime

How do the private constructor, private static field, and GetInstance() method
work together? Report your ReferenceEquals result. Does the same Logger object
survive when you quit and restart the application?

Write your answer here.

## 2. Severity choices

Choose one actual INFO, WARN, and ERROR entry from your log. Explain the event,
why its severity fits, and whether the program continued afterward.

Write your answer here.

## 3. Repository hygiene and privacy

Why should generated logs not normally be committed to GitHub? How did you
verify that SingletonLog.txt is ignored and untracked? What information did
you intentionally avoid logging?

Write your answer here.

## 4. Design tradeoffs

What does centralizing all logger output into a single file simplify? 
Can you think of any instances where a singleton Logger class can cause problems?
Think about various scenarios such as multi-threaded applications, unit testing, file access and write permissions.

Write your answer here.
