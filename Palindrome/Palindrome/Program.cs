
Console.Write("Enter the word: ");
string? input = Console.ReadLine();

if (String.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Invalid input.");
}

if (CheckPalindrome(input))
{
    Console.WriteLine($"{input} is a palindrome.");
}
else
{
    Console.WriteLine($"{input} is not a palindrome.");
}

bool CheckPalindrome(string input)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] != input[input.Length - 1 - i])
        {
            return false;
        }

        if (i == (input.Length / 2))
        {
            break;
        }
    }
    return true;
}