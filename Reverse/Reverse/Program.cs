
string pangram = "The quick brown fox jumps over the lazy dog";
string[] splitPangram = pangram.Split(" ");
string newPangram = "";

foreach (string item in splitPangram)
{
    char[] currentItemToChar = item.ToCharArray();
    Array.Reverse(currentItemToChar);
    string currentItemToString = new string(currentItemToChar);
    newPangram += (currentItemToString + " ");
}
newPangram.TrimEnd();

Console.WriteLine(newPangram);