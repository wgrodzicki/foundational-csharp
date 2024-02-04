// Reverses each word in a sentence

Console.Write("Enter a sentence to reverse: ");
string? sentence = Console.ReadLine();

if (String.IsNullOrWhiteSpace(sentence))
{
    Console.WriteLine("No sentence to reverse.");
}

sentence = sentence.Trim();

string reversedSentence = ReverseSentence(sentence);

Console.WriteLine(reversedSentence);


/// <summary>
/// Reverses each word in the given sentence
/// </summary>
/// <param name="input"></param>
/// <returns></returns>
string ReverseSentence(string input)
{
    // Determine the number of words in the sentence (assuming whitespace is the only separator)
    int numberOfWords = 1;

    foreach (char element in input)
    {
        if (element == ' ')
        {
            numberOfWords++;
        }
    }

    string[] words = new string[numberOfWords];
    string currentWord = "";
    int counter = 0;

    // Split the sentence into individual words
    for (int i = 0; i < input.Length; i++)
    {
        // Keep building a new word until a whitespace is met
        if (input[i] != ' ')
        {
            currentWord += input[i];
        }
        
        // When a whitespace is met or the sentence ends, save the new word and reset the placeholder one
        if (input[i] == ' ' || i == input.Length - 1)
        {
            words[counter] = currentWord;
            currentWord = "";
            counter++;
        }
    }

    string reversedSentence = "";

    // Reverse each word in the split sentence
    for (int i = 0; i < words.Length; i++)
    {
        reversedSentence += ReverseString(words[i]);
        
        // Rebuild the sentence adding whitespaces between individual words
        if (i != words.Length - 1)
        {
            reversedSentence += " ";
        }
    }

    return reversedSentence;
}


/// <summary>
/// Reverses the given string
/// </summary>
/// <param name="input"></param>
/// <returns></returns>
string ReverseString(string input)
{
    string reversed = "";

    for (int i = 0; i < input.Length; i++)
    {
        reversed += input[input.Length - 1 - i];
    }

    return reversed;
}