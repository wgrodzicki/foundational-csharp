
Console.Write("Purchase: ");
float purchase = float.Parse(Console.ReadLine());
float discountThreshold = 1000.0f;

// float discount = purchase > discountThreshold ? 100 : 50;

Console.WriteLine($"Eligible for {(purchase > discountThreshold ? 100 : 50)}% discount.");