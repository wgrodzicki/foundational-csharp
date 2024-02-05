
Random threshold = new Random();
Random die = new Random();

if (!ShouldPlay("Would you like to start the game? [y/n] "))
{
    return;
}

do
{
    int target = threshold.Next(1, 6);
    Console.WriteLine($"Target number to beat: {target}");

    Console.Write("Click Enter to roll the die...");
    Console.ReadLine();

    int roll = die.Next(1, 7);
    Console.WriteLine($"Your roll: {roll}");

    WinOrLose(target, roll);

} while (ShouldPlay("Would you like to continue playing? [y/n] "));


void WinOrLose(int target, int roll)
{
    if (roll > target)
    {
        Console.WriteLine("Congratulations, you win!");
    }
    else
    {
        Console.WriteLine("You lose.");
    }
}


bool ShouldPlay(string text)
{
    string? response;

    do
    {
        Console.WriteLine();
        Console.Write(text);
        response = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(response));

    response = response.Trim().ToLower();

    if (response == "y")
    {
        Console.WriteLine();
        return true;
    }
    else
    {
        return false;
    }
}