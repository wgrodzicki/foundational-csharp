
// ToString()
int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message);


// Helper method
string third = "5";
string fourth = "7";
// int sum = int.Parse(third) + int.Parse(fourth);
int thirdParsed = 0;
int fourthParsed = 0;
int sum = 0;

if (int.TryParse(third, out thirdParsed) && int.TryParse(fourth, out fourthParsed))
{
    sum = thirdParsed + fourthParsed;
}

Console.WriteLine(sum);


// Convert class - best to use for converting floats to ints (performs rounding)
float value1 = 5.7f;
float value2 = 7.6f;
// string value1 = "5";
// string value2 = "7";
int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
Console.WriteLine(result);


// TryParse()
string value = "102";
int resultValue = 0;
if (int.TryParse(value, out resultValue))
{
   Console.WriteLine($"Measurement: {resultValue}");
}
else
{
   Console.WriteLine("Unable to report the measurement.");
}
if (resultValue > 0)
    Console.WriteLine($"Measurement (w/ offset): {50 + resultValue}");