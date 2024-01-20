/*
Code snippet to reverse a string and count the number of times a particular character appears.
*/

string text = "The quick brown fox jumps over the lazy dog.";

char[] convertedText = text.ToCharArray();
Array.Reverse(convertedText);

char targetLetter = 'o';
int letterCounter = 0;

foreach (char i in convertedText)
{
    if (i == targetLetter)
    {
        letterCounter++;
    }
}

string reversedText = new String(convertedText);

Console.WriteLine(reversedText);
Console.WriteLine($"{targetLetter} appears {letterCounter} times.");