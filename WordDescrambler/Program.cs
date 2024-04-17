// Word Descrambler
using System.Text.RegularExpressions;

// get scrambled word and validate input
String scrambledWord = "";
do
{
    try
    {
        Console.Write("Please enter a scrambled word: ");
        scrambledWord = Console.ReadLine();
    }
    catch (Exception e)
    {
        Console.WriteLine("Error while reading user input: " + e.Message);
    }

} while (!isStringOnlyLetters(scrambledWord));

// Generate all possible combinations of letters
HashSet<string> combinations = getCombinationsOfLetters("", scrambledWord);

// Read word List file
HashSet<string> wordList = readWordListFile(@"resources\1000-most-common-words.txt");

// Compare scrambled combinations to wordlist
Console.WriteLine($"English words from the letters in '{scrambledWord}' are:");
foreach (string combination in combinations)
{
    if (wordList.Contains(combination.ToLower()))
    {
        Console.WriteLine(combination);
    }
}

// Keep the console window open until user is finished
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static HashSet<string> readWordListFile(string filePath)
{
    HashSet<string> wordList = new HashSet<string>();

    try
    {
        var words = File.ReadLines(filePath);
        foreach (var word in words)
        {
            // Ensure wordlist is always lower case
            wordList.Add(word.ToLower());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error while reading the file: " + e.Message);
    }
    return wordList;
}

static HashSet<string> getCombinationsOfLetters(string currentCombination, string remaining)
{
    HashSet<string> combinations = new HashSet<string>();
    combinations.Add(currentCombination);

    //Exit condition
    if (remaining.Length < 1)
    {
        return combinations;
    }

    // itterate through each letter of string
    for (int i = 0; i < remaining.Length; i++)
    {
        string letter = remaining.Substring(i, 1);
        string newRemaining = remaining.Remove(i, 1);
        // recursively add substring letters
        combinations.UnionWith(getCombinationsOfLetters(currentCombination + letter, newRemaining));
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
