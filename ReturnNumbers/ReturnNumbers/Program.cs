double usd = 23.73;
int vnd = UsdToVnd(usd);

Console.WriteLine($"{usd:C2} USD = {vnd:C2} VND");
Console.WriteLine($"{vnd:C2} VND = {VndToUsd(vnd):C2} USD");

int UsdToVnd(double usd)
{
    return (int)(usd * 23500);
}

double VndToUsd(int vnd)
{
    return vnd / 23500.00;
}