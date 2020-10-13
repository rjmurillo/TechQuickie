# Reverse words in place

## Task: write a method that takes a set of words and reverses their order _in place_

>When asked to perform this function _in place_, the interviewer is providing requirements and testing your knowledge: you need to modify the input, which means you need a *mutable* input data type, like an `Array`. C#'s `String` type is [_immutable_](https://en.wikipedia.org/wiki/Immutable_object).

## Analysis

The interviewer's requirement suggests a method signature such as

```csharp
void ReverseWords(char[] input)
```

>In general, an in-place algorithm will require swapping elements, and can be achieved in *O(n)* time and *O(1)* space.

When authoring a solution, there are test cases to ensure complete code coverage:

- A null input
- An empty input
- An input of a single word
- An input of two words
- An input of three or more words
- An input of words of different lengths
- An input of words of the same length

>This is similar to the [Reverse in Place](../reverse-in-place/readme.md), where each character in the input was reversed.

To build on *Reverse in Place*, we'll need to figure out solutions to some new constraints:

1. The input deals with a stream of *words*, not just characters. Assume English as an input, how do we know where words begin and end?
1. Once the beginning and the end of a two words is known, how do we swap the two words?

First, let's try manipulating a sample by hand to understand the fundamentals and look for clues, using the *Reverse in Place* method.

```csharp
// input: lorem ipsum dolor amit
{'l', 'o', 'r', 'e', 'm', ' ', 'i', 'p', 's', 'u', 'm',
 'd', 'o', 'l', 'o', 'r', ' ', 'a', 'm', 'i', 't', }

// characters reversed: timea rolod muspi merol
{'t', 'i', 'm', 'a', ' ', 'r', 'o', 'l', 'o', 'd', ' ',
 'm', 'u', 's', 'p', 'i', ' ', 'm', 'e', 'r', 'o', 'l'}

 // desired result: amit dolor ipsum lorem
 {'a', 'm', 'i', 't', ' ', 'd', 'o', 'l', 'o', 'r',
  'i', 'p', 's', 'u', 'm', ' ', 'l', 'o', 'r', 'e', 'm'}
```

>Often by breaking down the problem into the most basic elements, then reasoning up from there, will you find patterns or hints that can help you along.

Notice two things:

1. The character reversal reverses the words and the letters in each word
1. In order to meet the requirements, each word needs to be reversed in place again for proper right-to-left character order

> **What happens if we just use the spaces?**
> Given our first intuition to locate the spaces, and given two words of unequal length, how long would it take to swap them? Supposing we already knew the start and end indices in the input array, it would be _O(n)_ time.
> However, when we move what was in the front to the back and the back to the front, we have to move everything over in between the two.
>
> ```csharp
> // input: a bb c dd e ff g hh
> {'a', ' ', 'b', 'b', ' ', 'c', ' ', 'd', 'd', ' ',
>  'e', ' ', 'f', 'f', ' ', 'g', ' ', 'h', 'h'}
> ```
>
> We take *O(n)* time to swap the first and last words (we have to move all *n* characters):
>
> ```csharp
> // input: a bb c dd e ff g hh
> {'a', ' ', 'b', 'b', ' ', 'c', ' ', 'd', 'd', ' ',
>  'e', ' ', 'f', 'f', ' ', 'g', ' ', 'h', 'h'}
>
> // first swap: hh bb c dd e ff g a
> {'h', 'h', ' ', 'b', 'b', ' ', 'c', ' ', 'd', 'd', 
>  ' ', 'e', ' ', 'f', 'f', ' ', 'g', ' ', 'a'}
> ```
>
> Then for the second swap:
>
> ```csharp
> // input: a bb c dd e ff g hh
> {'a', ' ', 'b', 'b', ' ', 'c', ' ', 'd', 'd', ' ',
>  'e', ' ', 'f', 'f', ' ', 'g', ' ', 'h', 'h'}
>
> // first swap: hh bb c dd e ff g a
> {'h', 'h', ' ', 'b', 'b', ' ', 'c', ' ', 'd', 'd',
>  ' ', 'e', ' ', 'f', 'f', ' ', 'g', ' ', 'a'}
>
> // second swap: hh g c dd e ff bb a
> {'h', 'h', ' ', 'g', ' ', 'c', ' ', 'd', 'd',
>  ' ', 'e', ' ', 'f', 'f', ' ', 'b', 'b', ' ', 'a'}
>
> ```
>
> We have to move all *n* characters *except* the first and last words (*n - 5)* in total). For the third swap we have another 5 characters we don't have to move, so we move *n-10* in total, ending up with a mathmatical series like this: *n + (n-5) + (n-10) + (n-15) + ... + 6 + 1*, so *O(n^2)* time--not good.

# Solution

Through analysis we determined that reversing the characters on the whole input got us to step 1, then each word needed to be reversed again. This gives us two functions, one for the perspective of the words in a sentence, the others for the perspective of a single word.

```csharp
public static void ReverseWords(char[] chars)
{
    if (chars == null)
    {
        return;
    }

    // First we need to reverse all the characters in the entire input
    ReverseCharacters(chars, 0, chars.Length - 1);

    // Now the input is in the right word order, but every word is backward
    // Now we'll make the words forward again by reversing each word's characters

    // We hold the index of the start of the current word as we look for the end of the current word
    const char wordBreak = ' ';
    int currentWordStartIndex = 0;
    for (int i = 0; i <= chars.Length; i++)
    {
        // Found the end of the current word
        if (i == chars.Length || chars[i] == wordBreak)
        {
            // If we haven't exhausted the array, our next word's start is i+1
            ReverseCharacters(chars, currentWordStartIndex, i-1);
            currentWordStartIndex = i + 1;
        }
    }
}

// This is a slightly modified version from Reverse in Place
// Same variables, except the left and right index are promoted to parameters
private static void ReverseCharacters(char[] chars, int leftIndex, int rightIndex)
{
    if (chars == null)
    {
        return;
    }

    // We swap the first and last characters, then the second and second to last until we reach the middle
    while (leftIndex < rightIndex)
    {
        // Swap
        char temp = chars[leftIndex];
        chars[leftIndex] = chars[rightIndex];
        chars[rightIndex] = temp;

        // Move towards the middle
        leftIndex++;
        rightIndex--;
    }
}
```