/*
Accepting user input as integer
*/

string? input;
int number = 0;
bool inputValid = false;

do
{
    Console.Write("Input an integer between 5 and 10 (included): ");
    input = Console.ReadLine();
    
    if (!int.TryParse(input, out number) || number < 5 || number > 10)
    {
        Console.WriteLine($"\"{input}\" is not a valid input.");
    }
    else
    {
        inputValid = true;
    }

} while (!inputValid);

Console.WriteLine("Input accepted.");