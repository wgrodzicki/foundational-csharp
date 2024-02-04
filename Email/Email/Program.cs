string[,] corporate = 
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external = 
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

for (int i = 0; i < corporate.GetLength(0); i++) 
{
    // display internal email addresses
    DisplayEmail(corporate[i,0], corporate[i,1]);
}

for (int i = 0; i < external.GetLength(0); i++) 
{
    // display external email addresses
    DisplayEmail(external[i,0], external[i,1], externalDomain);
}

void DisplayEmail(string name, string surname, string domain = "contoso.com")
{
    string email = name.Remove(2).ToLower() + surname.ToLower() + "@" + domain;
    Console.WriteLine(email);
}