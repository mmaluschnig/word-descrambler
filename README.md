# word-descrambler

### Instructions

Develop a C# console application that takes a scrambled word as input, generates all possible combinations of letters, and searches for valid English words in a provided word list file.

### Notes

- Kept the capital letters from the original scrambled string to display in the output in case they are relevant. e.g. "Ccat" can return both "Cat" and "cat".
- Added top 10000 english words to test performance but this file contains things like "c" and "ct" as words so I prefer to use top 1000 words for nicer results.
