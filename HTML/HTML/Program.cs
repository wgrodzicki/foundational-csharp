
const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here
const string spanTagOpen = "<span>";
const string spanTagClose = "</span>";
const string divTagOpen = "<div>";
const string divTagClose = "</div>";
const string tm = "&trade";
const string registered = "&reg";

quantity = input.Substring(input.IndexOf(spanTagOpen) + spanTagOpen.Length);
quantity = quantity.Remove(quantity.IndexOf(spanTagClose));

output = input.Substring(input.IndexOf(divTagOpen) + divTagOpen.Length);
output = output.Remove(output.IndexOf(divTagClose), divTagClose.Length);
output = output.Replace(tm, registered);

Console.WriteLine($"Quantity: {quantity}");
Console.WriteLine($"Output: {output}");