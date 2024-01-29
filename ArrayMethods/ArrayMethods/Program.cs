string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
string newValue = new string(valueArray);
string separatedValue = String.Join(":", valueArray);
string[] splitValue = separatedValue.Split(":");

Console.WriteLine(value);
Console.WriteLine(newValue);
Console.WriteLine(separatedValue);

foreach (string element in splitValue)
{
    Console.WriteLine(element);
}