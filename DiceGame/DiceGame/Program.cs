int numberRolls = 0;

int points = 0;
int doubleBonus = 2;
int tripleBonus = 6;

string prize1 = "car";
string prize2 = "laptop";
string prize3 = "trip";
string prize4 = "kitten";

do
{
    Console.Write("Number of rolls: ");
} while (!Int32.TryParse(Console.ReadLine(), out numberRolls));

int minScore1 = (numberRolls * 5) + 1;
int minScore2 = (numberRolls * 3) + 1;
int minScore3 = (numberRolls * 2) + 1;

Random dice = new Random();
int[] rolls = new int[numberRolls];

for (int i = 0; i < numberRolls; i++)
{
    rolls[i] = dice.Next(1, 7);
    Console.WriteLine($"Roll {i}: {rolls[i]}");

    points += rolls[i];
    Console.WriteLine($"Current points: {points}");
}

for (int i = 0; i < numberRolls; i++)
{
    int counter = 1;

    for (int j = 0; j < numberRolls; j++)
    {
        if (i == j || rolls[j] == -1)
        {
            continue;
        }

        if (rolls[i] == rolls[j])
        {
            counter++;
            rolls[j] = -1;
        }
    }

    rolls[i] = -1;

    if (counter == 2)
    {
        points += doubleBonus;
        Console.WriteLine($"Bonus +{doubleBonus}");
    }

    if (counter >= 3)
    {
        points += tripleBonus;
        Console.WriteLine($"Bonus +{tripleBonus}");
    }
}

Console.WriteLine($"Your score: {points}");

if (points >= minScore1)
{
    Console.WriteLine($"You win a {prize1}!");
}
else if (points >= minScore2)
{
    Console.WriteLine($"You win a {prize2}!");
}
else if (points >= minScore3)
{
    Console.WriteLine($"You win a {prize3}!");
}
else
{
    Console.WriteLine($"You win a {prize4}!");
}