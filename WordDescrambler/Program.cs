// Word Descrambler
using System.Text.RegularExpressions;

// get scrambled word and validate input
String scrambledWord;
do
{
    //TODO: Add try-catch
    Console.Write("Please enter a scrambled word: ");
    scrambledWord = Console.ReadLine();

} while (!isStringOnlyLetters(scrambledWord));

// Generate all possible combinations of letters
HashSet<string> combinations = getCombinationsOfLetters("", scrambledWord);
foreach (string word in combinations)
{
    Console.WriteLine(word);
}

// Read word List file
HashSet<string> wordList = readWordListFile("1000-most-common-words.txt");

// Compare scrambled combinations to wordlist
Console.WriteLine($"English words from the letters in '{scrambledWord}' are:");
foreach (string combination in combinations)
{
    if (wordList.Contains(combination.ToLower()))
    {
        Console.WriteLine(combination);
    }
}

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

static HashSet<string> getCombinationsOfLetters(string prefix, string s)
{
    HashSet<string> combinations = new HashSet<string>();

    //Exit condition
    if (s.Length < 1)
    {
        combinations.Add(prefix + s);
        return combinations;
    }

    combinations.Add(prefix + s);

    // itterate through each letter of string
    for (int i = 0; i < s.Length; i++)
    {
        string letter = s.Substring(i, 1);
        string remainingLetters = s.Remove(i, 1);
        // recursively add substring letters
        combinations.UnionWith(getCombinationsOfLetters(letter, remainingLetters));
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
