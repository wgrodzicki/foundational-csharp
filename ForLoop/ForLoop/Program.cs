/*
FizzBuzz challenge
*/

int upperLimit = 0;

do
{
    Console.Write("Upper limit value: ");
} while (!Int32.TryParse(Console.ReadLine(), out upperLimit));

for (int i = 1; i <= upperLimit; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
        Console.WriteLine($"{i} FizzBuzz");
    else if (i % 3 == 0)
        Console.WriteLine($"{i} Fizz");
    else if (i % 5 == 0)
        Console.WriteLine($"{i} Buzz");
    else
        Console.WriteLine(i);
}