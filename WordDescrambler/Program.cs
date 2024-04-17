// Word Descrambler
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
