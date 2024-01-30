
// int invoiceNumber = 1201;
// decimal productShares = 25.4568m;
// decimal subtotal = 2750.00m;
// decimal taxPercentage = .15825m;
// decimal total = 3185.19m;

// Console.WriteLine($"\tInvoice Number: {invoiceNumber}");
// Console.WriteLine($"\tProduct Shares: {productShares:N3}");
// Console.WriteLine($"\tSubtotal: {subtotal:C}");
// Console.WriteLine($"\tTax: {taxPercentage:P2}");
// Console.WriteLine($"\tTotal: {total:C}");

string paymentId = "769C";
string payeeName = "Mr. Stephen Ortega";
string paymentAmount = "$5,000.00";

string formattedLine = paymentId.PadRight(6,'-');
formattedLine += payeeName.PadRight(24, '-');
formattedLine += paymentAmount.PadLeft(10, '-');

Console.WriteLine("1234567890123456789012345678901234567890");
Console.WriteLine(formattedLine);
