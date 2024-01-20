
int[] inventory = { 200, 450, 700, 175, 250 };

int bin = 0;
int sum = 0;

foreach (int item in inventory)
{
    bin++;
    sum += item;
    Console.WriteLine($"Bin {bin}: {item}\nRunning total: {sum}");
}

Console.WriteLine($"Total sum: {sum}");