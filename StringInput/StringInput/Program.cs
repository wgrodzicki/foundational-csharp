/*
Accept string as input
*/

string? input;
bool inputValid = false;

do
{
    Console.Write("Enter role [Administrator | Manager | User]: ");
    input = Console.ReadLine();

    if (input != null)
    {
        input = input.Trim().ToLower();
    }

    switch (input)
    {
        case "administrator":
            inputValid = true;
            break;
        case "manager":
            inputValid = true;
            break;
        case "user":
            inputValid = true;
            break;
        default:
            Console.WriteLine($"\"{input}\" is not a valid input.");
            continue;
    }

} while (!inputValid);

Console.WriteLine("Input accepted.");