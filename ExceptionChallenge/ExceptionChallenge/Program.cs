string[][] userEnteredValues = new string[][]
{
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
};

try
{
    Workflow1(userEnteredValues);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(ex.Message);
    Console.WriteLine();
}

static void Workflow1(string[][] userEnteredValues)
{
    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            Process1(userEntries);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    }
    Console.WriteLine("'Worflow1' completed successfully.");
    Console.WriteLine();
}

static void Process1(String[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        if (!int.TryParse(userValue, out valueEntered))
        {
            throw new FormatException("Invalid data. User input values must be valid integers.");
        }

        if (valueEntered == 0)
        {
            throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
        }

        checked
        {
            int calculatedValue = 4 / valueEntered;
        }
    }
    Console.WriteLine("'Process1' completed successfully.");
    Console.WriteLine();
}