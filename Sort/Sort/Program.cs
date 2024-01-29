
string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
string[] splitOrderStream = orderStream.Split(",");
Array.Sort(splitOrderStream);

foreach (string order in splitOrderStream)
{
    if (order.Length != 4)
    {
        Console.WriteLine($"{order}\t- Error");
    }
    else
    {
        Console.WriteLine(order);
    }
}