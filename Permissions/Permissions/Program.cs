string permission = "sth";
int level = 6;
string message = "";

if (permission.Trim().ToLower().Contains("admin"))
{
    message = level > 55 ? "Welcome, Super Admin user." : "Welcome, Admin user.";
}
else if (permission.Trim().ToLower().Contains("manager"))
{
    message = level >= 20 ? "Contact an Admin for access." : "You do not have sufficient privileges.";
}
else
{
    message = "You do not have sufficient privileges.";
}

Console.WriteLine(message);