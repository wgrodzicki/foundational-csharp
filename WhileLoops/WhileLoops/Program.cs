
Random randomGenerator = new Random();
int number = 0;

number = randomGenerator.Next(1, 11);
Console.WriteLine(number);

while (number > 1)
{
    number = randomGenerator.Next(1, 11);
    if (number == 5)
    {
        Console.WriteLine("continue");
        continue;
    } 
    Console.WriteLine(number);
};