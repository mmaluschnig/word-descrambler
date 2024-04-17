// Word Descrambler
using System.Collections;
using System.Text.RegularExpressions;


// get scrambled word and validate input

String scrambledWord;
do
{
    //TODO: Add try-catch
    Console.Write("Please enter a scrambled word:");
    scrambledWord = Console.ReadLine();

} while (!isStringOnlyLetters(scrambledWord));

Console.WriteLine($"Scrambled word is: {scrambledWord}.");

// Generate all possible combinations of letters

foreach (string word in getCombinationsOfLetters("", scrambledWord))
{
    Console.WriteLine(word);
}

static ArrayList getCombinationsOfLetters(string prefix, string s)
{
    ArrayList combinations = [s];

    //Exit condition
    if (s.Length <= 1)
    {
        return combinations;
    }

    combinations.Add(prefix + s);


    // itterate through each letter of string
    for (int i = 0; i < s.Length; i++)
    {
        string letter = s.Substring(i, 1);
        string remainingLetters = s.Remove(i, 1);
        // recursively add substring letters
        combinations.AddRange(getCombinationsOfLetters(letter, remainingLetters));
    }
    return combinations;
}

static bool isStringOnlyLetters(string s)
{
    if (string.IsNullOrWhiteSpace(s))
    {
        Console.WriteLine("Invalid word. Please try again.");
        return false;
    }

    if (!Regex.IsMatch(s, @"^[a-zA-Z]+$"))
    {
        Console.WriteLine("Word must contain only upper and lower case letters. Please try again.");
        return false;
    };

    return true;
}
