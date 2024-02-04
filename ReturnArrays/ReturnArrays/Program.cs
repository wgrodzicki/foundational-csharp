// Finds all (distinct) pairs that add up to the given value

int[] coins = new int[] {5, 5, 50, 25, 25, 10, 5};
int targetValue;

// Get valid input
do
{
    Console.Write("Enter target value: ");
} while (!int.TryParse(Console.ReadLine(), out targetValue));

int[,] coinsFound = TwoCoins(coins, targetValue);

if (coinsFound.Length == 0)
{
    Console.WriteLine($"No coin pairs of total value equal to {targetValue} have been found.");
}
else
{
    Console.WriteLine($"Positions of coins that add up to {targetValue}:");
    
    // Print all pairs found (bypass empty pairs)
    for (int i = 0; i < coinsFound.GetLength(0); i++)
    {
        if (coinsFound[i,0] == 0 && coinsFound[i,1] == 0)
        {
            break;
        }
        Console.WriteLine($"{coinsFound[i,0]} and {coinsFound[i,1]}");
    }
}

/// <summary>
/// Finds all pairs in the given array that add up to the target value
/// </summary>
/// <param name="coins"></param>
/// <param name="targetValue"></param>
/// <returns></returns>
int[,] TwoCoins(int[] coins, int targetValue) 
{
    // Equation to find the number of all possible distinct pairs within the given number
    int maxDifferentPairsPossible = (int)((coins.Length - 1) + Math.Pow((coins.Length - 1), 2)) / 2;

    // Allocate enough space for all possible pairs
    int[,] matchingPairs = new int[maxDifferentPairsPossible,2];

    int counter = 0;
    bool countPair = true;

    // Compare all values within the given array
    for (int i = 0; i < coins.Length; i++)
    {
        for (int j = 0; j < coins.Length; j++)
        {
            countPair = true;

            if (i == j)
            {
                continue;
            }

            if (coins[i] + coins[j] == targetValue)
            {
                // Check if the pair has been already found
                for (int k = 0; k < matchingPairs.GetLength(0); k++)
                {
                    if ((matchingPairs[k,0] == i && matchingPairs[k,1] == j)
                        || (matchingPairs[k,0] == j && matchingPairs[k,1] == i))
                    {
                        countPair = false; 
                    }
                }

                if (!countPair)
                {
                    continue;
                }

                // Save current pair
                matchingPairs[counter,0] = i;
                matchingPairs[counter,1] = j;
                counter++;
            }
        }
    }

    if (counter > 0)
    {
        return matchingPairs;
    }
    return new int[0,0];
}