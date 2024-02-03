// Validates IP address

string? input;

Console.Write("Enter IP address: ");
input = Console.ReadLine();

if (!String.IsNullOrWhiteSpace(input))
{
    if (CheckNumbers(input))
        Console.WriteLine($"IP address of {input} is valid.");
    else
        Console.WriteLine($"IP address of {input} is invalid.");
}
else
{
    Console.WriteLine($"IP address of {input} is invalid.");
}

// Check for 4 numbers separated by dots
bool CheckNumbers(string address)
{
    if (!address.Contains('.'))
        return false;

    string[] addressSubstrings = address.Split(".");

    if (addressSubstrings.Length != 4)
        return false;

    foreach (string addressSubstring in addressSubstrings)
    {
        if (addressSubstring.Length >= 2 && !CheckZeroes(addressSubstring))
            return false;

        int currentNumber;

        if (!int.TryParse(addressSubstring, out currentNumber))
            return false;

        if (!CheckRange(currentNumber))
            return false;
    }
    return true;
}

// Check for leading zeroes in each number
bool CheckZeroes(string addressSubstring)
{
    if (addressSubstring.StartsWith("0"))
        return false;
    else
        return true;
}

// Check for number range (0-255)
bool CheckRange(int addressFragment)
{
    if (addressFragment < 0 || addressFragment > 255)
        return false;
    else
        return true;
}