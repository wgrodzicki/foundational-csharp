/*
RPG combat simulator
*/

int playerHealth = 10;
int monsterHealth = 10;

Console.WriteLine($"Player's health: {playerHealth}");
Console.WriteLine($"Monster's health: {monsterHealth}");

Random random = new Random();
int playerAttack = 0;
int monsterAttack = 0;

do
{
    // Player's turn
    Console.WriteLine("\nPlayer attacks...");
    playerAttack = random.Next(1, 10);
    monsterHealth -= playerAttack;

    Console.WriteLine($"Monster lost {playerAttack} HP");
    if (monsterHealth <= 0)
    {
        Console.WriteLine("Monster is dead! Player wins!");
        break;
    }
    Console.WriteLine($"Monster's current HP is {monsterHealth}");

    // Monster's turn
    Console.WriteLine("\nMonster attacks...");
    monsterAttack = random.Next(1, 10);
    playerHealth -= monsterAttack;

    Console.WriteLine($"Player lost {monsterAttack} HP");
    if (playerHealth <= 0)
    {
        Console.WriteLine("Player is dead! Monster wins!");
        break;
    }
    Console.WriteLine($"Player's current HP is {playerHealth}");
} while (playerHealth > 0);