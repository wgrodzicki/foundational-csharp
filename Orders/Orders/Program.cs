
// int size = 0;
// string[] fraudulentOrders;
// // string[] fraudulentOrders = { "123", "234", "345" };

// void GetSize()
// {
//     bool inputValid = false;

//     do
//     {
//         Console.Write("Number of orders: ");
//         string input = Console.ReadLine();

//         if (String.IsNullOrEmpty(input))
//         {
//             continue;
//         }

//         if (Int32.TryParse(input, out size))
//         {
//             inputValid = true;
//         }

//     } while (!inputValid);
// }

// void GetOrders()
// {
//     for (int i = 0; i < size; i++)
//     {
//         Console.Write($"Order {i} ID: ");
//         string orderId = Console.ReadLine();

//         if (!String.IsNullOrEmpty(orderId))
//         {
//             fraudulentOrders[i] = orderId;
//         }
//     }
// }

// void PrintOrders()
// {
//     for (int i = 0; i < fraudulentOrders.Length; i++)
//     {
//         Console.WriteLine($"Order {i}: {fraudulentOrders[i]}");
//     }
// }

// GetSize();

// fraudulentOrders = new string[size];

// GetOrders();
// PrintOrders();

// Console.WriteLine($"Number of fraudulent orders: {fraudulentOrders.Length}");

string[] orders = { "B123",
                    "C234",
                    "A345",
                    "C15",
                    "B177",
                    "G3003",
                    "C235",
                    "B179" };

foreach (string order in orders)
{
    if (order.StartsWith("B"))
    {
        Console.WriteLine(order);
    }
}




