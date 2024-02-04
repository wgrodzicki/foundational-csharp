// Reverses a string without using the built-in Reverse() method

Console.Write("String to reverse: ");
string? input = Console.ReadLine();

if (input == null)
{
    Console.WriteLine("No string to reverse");
}

string reversedString = ReverseString(input);

Console.WriteLine(reversedString);

string ReverseString(string input)
{
    string reversed = "";

    for (int i = 0; i < input.Length; i++)
    {
        reversed += input[input.Length - 1 - i];
    }

    return reversed;
}
