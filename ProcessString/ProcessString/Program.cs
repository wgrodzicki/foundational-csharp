/*
Processes string input
*/

string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

int periodLocation = 0;

for (int i = 0; i < myStrings.Length; i++)
{
    string myString = myStrings[i];
    periodLocation = myString.IndexOf(".");

    while (periodLocation != -1)
    {
        string leadingString = myString.Remove(periodLocation);
        leadingString = leadingString.TrimStart().TrimEnd();
        Console.WriteLine(leadingString);
        myString = myString.Substring(periodLocation + 1);
        periodLocation = myString.IndexOf(".");
    }

    if (!String.IsNullOrEmpty(myString))
    {
        Console.WriteLine(myString.TrimStart().TrimEnd());
    }
}

