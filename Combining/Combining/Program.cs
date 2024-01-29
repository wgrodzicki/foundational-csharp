
string[] values = { "12.3", "45", "ABC", "11", "DEF" };
string alphabetical = "";
decimal sum = 0.0m;

foreach (String value in values)
{
    decimal currentNumber;
    if (decimal.TryParse(value, out currentNumber))
    {
        sum += currentNumber;
    }
    else
    {
        alphabetical += value;
    }
}

Console.WriteLine(alphabetical);
Console.WriteLine(sum);