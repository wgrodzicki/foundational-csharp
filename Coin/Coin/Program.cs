
Random coin = new Random();
int coinFlip = coin.Next(0, 2);
Console.WriteLine($"{coinFlip}: {(coinFlip >= 1 ? "heads" : "tails")}");