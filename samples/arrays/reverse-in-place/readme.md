# Reverse a String in Place

## Task: Write a method that takes an array of characters and reverses the letters _in place_

>When asked to perform this function _in place_, the interviewer is providing requirements and testing your knowledge: you need to modify the input, which means you need a *mutable* input data type, like an `Array`. C#'s `String` type is [_immutable_](https://en.wikipedia.org/wiki/Immutable_object).

## Analysis

The interviewer's requirement suggests a method signature such as

```csharp
void Reverse(char[] input)
```

>In general, an in-place algorithm will require swapping elements, and can be achieved in _O(n)_ time and _O(1)_ space.

When authoring a solution, there are test cases to ensure complete code coverage:
 - A null input
 - An empty input
 - An input of a single character
 - An input of two characters
 - An input of three or more characters