/*
Simulates school visits to a zoo
*/

using System;
using System.Diagnostics.Metrics;

string[] pettingZoo = 
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

int schoolCount = GetSchoolCount();
Console.WriteLine();

for (int i = 0; i < schoolCount; i++)
{
    School school = GetSchool();
    string[] randomizedAnimals = RandomizeAnimals(pettingZoo);
    
    Console.WriteLine();
    PrintSchool(school);
    Console.WriteLine();

    bool eachGroupVisitsAllAnimals = GetVisitMode();

    if (eachGroupVisitsAllAnimals)
        VisitAllAnimalsByEachGroup(randomizedAnimals: randomizedAnimals, school: school);
    else
        VisitAnimals(randomizedAnimals: randomizedAnimals, school: school);
}


/// <summary>
/// Gets the number of visiting schools
/// </summary>
/// <returns></returns>
int GetSchoolCount()
{
    string? schoolCountInput;
    int schoolCount;
    bool inputValid = false;

    do
    {
        Console.WriteLine();
        Console.Write("Number of visiting schools: ");
        schoolCountInput = Console.ReadLine();
        inputValid = int.TryParse(schoolCountInput, out schoolCount);

        if (inputValid && schoolCount <= 0)
        {
            inputValid = false;
        }

    } while (!inputValid);

    return schoolCount;
}


/// <summary>
/// Register school from the user input
/// </summary>
/// <returns></returns>
School GetSchool()
{
    // Name
    string? name;

    do
    {
        Console.Write("Name of the visiting school: ");
        name = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(name));

    string? groupsInput;
    int groups;
    bool groupsValid = false;

    // Number of groups
    do
    {
        Console.Write("Number of groups from the visiting school: ");
        groupsInput = Console.ReadLine();
        groupsValid = int.TryParse(groupsInput, out groups);

        if (groupsValid && groups <= 0)
        {
            groupsValid = false;
        }

    } while (!groupsValid);

    // Register school
    School school = new School();
    school.name = name;
    school.groups = new Group[groups];

    for (int i = 0; i < groups; i++)
    {
        school.groups[i].index = i;
        school.groups[i].visitedAnimals = "";
    }

    return school;
}


/// <summary>
/// Randomizes animals in the zoo
/// </summary>
/// <param name="animals"></param>
/// <returns></returns>
string[] RandomizeAnimals(string[] animals)
{
    string[] randomizedAnimals = new string[animals.Length];

    int[] randomIndexes = new int[animals.Length];

    for (int i = 0; i < animals.Length; i++)
    {
        randomIndexes[i] = -1;
    }

    for (int i = 0; i < animals.Length; i++)
    {
        // Keep putting animals in random order in the randomized array until all slots are occupied
        while (String.IsNullOrEmpty(randomizedAnimals[i]))
        {
            Random random = new Random();
            int randomIndex = random.Next(0, animals.Length);
            bool randomIndexValid = true;

            // Make sure this index has not been used yet
            for (int j = 0; j < randomIndexes.Length; j++)
            {
                if (randomIndex == randomIndexes[j])
                {
                    randomIndexValid = false;
                    break;
                }
            }

            if (randomIndexValid)
            {
                randomizedAnimals[i] = animals[randomIndex];
                randomIndexes[i] = randomIndex;
            }
        }
    }
    return randomizedAnimals;
}


/// <summary>
/// Simulates school groups visiting animals: each group visits all animals once and all animals visited at the same time must be different for each group
/// </summary>
/// <param name="school"></param>
/// <param name="randomizedAnimals"></param>
void VisitAllAnimalsByEachGroup(School school, string[] randomizedAnimals)
{
    AnimalVisit[] animalVisits = new AnimalVisit[randomizedAnimals.Length];

    for (int i = 0; i < animalVisits.Length; i++)
    {
        animalVisits[i].animal = randomizedAnimals[i];
        animalVisits[i].isBeingVisited = false;
        animalVisits[i].totalVisits = 0;
    }

    int animalsVisitedByAllGroups = 0;

    Console.WriteLine();

    // Keep simulating visits until all animals have been visited by all groups
    while (animalsVisitedByAllGroups < animalVisits.Length)
    {
        // Reset current visits
        for (int i = 0; i < animalVisits.Length; i++)
        {
            animalVisits[i].isBeingVisited = false;
        }

        for (int i = 0; i < school.groups.Length; i++)
        {
            for (int j = 0; j < animalVisits.Length; j++)
            {
                // Animals not currently visited by another group
                if (animalVisits[j].isBeingVisited)
                {
                    continue;
                }

                // Animals not visited by all groups
                if (animalVisits[j].totalVisits >= school.groups.Length)
                {
                    continue;
                }

                // Animals not visited by this particular group
                if (school.groups[i].visitedAnimals.Contains(animalVisits[j].animal))
                {
                    continue;
                }

                animalVisits[j].isBeingVisited = true;
                animalVisits[j].totalVisits++;

                // Increase counter if this is the last possible visit
                if (animalVisits[j].totalVisits == school.groups.Length)
                {
                    animalsVisitedByAllGroups++;
                }

                school.groups[i].visitedAnimals += animalVisits[j].animal;
                Console.WriteLine($"Group {school.groups[i].index + 1} visits: {animalVisits[j].animal}");
                break;
            }
        }
        Console.WriteLine();
    }
}


/// <summary>
/// Simulates school groups visiting animals: each groups visits different animals (but not all), so that all animals get visited
/// </summary>
/// <param name="school"></param>
/// <param name="randomizedAnimals"></param>
void VisitAnimals(School school, string[] randomizedAnimals)
{
    int animalsPerGroup = randomizedAnimals.Length / school.groups.Length;
    int remainingAnimals = randomizedAnimals.Length % school.groups.Length;
    int animalCounter = 0;

    for (int i = 0; i < school.groups.Length - 1; i++)
    {
        Console.WriteLine();
        Console.Write($"Group {school.groups[i].index + 1} visits:");

        do
        {
            Console.Write($" {randomizedAnimals[animalCounter]}");
            animalCounter++;
        } while (animalCounter % animalsPerGroup != 0);
    }

    Console.WriteLine();
    Console.Write($"Group {school.groups[school.groups.Length - 1].index + 1} visits:");

    while (animalCounter < randomizedAnimals.Length)
    {
        Console.Write($" {randomizedAnimals[animalCounter]}");
        animalCounter++;
    }
    Console.WriteLine();
}


/// <summary>
/// Prints the name of the school
/// </summary>
/// <param name="school"></param>
void PrintSchool(School school)
{
    Console.WriteLine($"School: {school.name}");
}


/// <summary>
/// Gets visit mode
/// </summary>
/// <returns></returns>
bool GetVisitMode()
{
    string? mode;

    do
    {
        Console.Write("Should each school group visit all animals in the zoo? [y/n] ");
        mode = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(mode));

    mode = mode.Trim().ToLower();

    return mode == "y" ? true : false;
}


struct School
{
    public string name;
    public Group[] groups;
}


struct Group
{
    public int index;
    public string visitedAnimals;
}


struct AnimalVisit
{
    public string animal;
    public bool isBeingVisited;
    public int totalVisits;
}