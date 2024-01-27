/*
Contoso Pets application, an application that helps place pets in new homes.
*/


using System.Diagnostics.Metrics;

const int MAX_ANIMALS = 10;
List<Animal> ourAnimals = new List<Animal>();


/// <summary>
/// Prints selected animal data
/// </summary>
/// <param name="animal"></param>
void PrintAnimalData(Animal animal)
{
    Console.WriteLine($"Animal ID: {animal.id}");
    Console.WriteLine($"Animal species: {animal.species}");
    Console.WriteLine($"Animal age: {animal.age}");
    Console.WriteLine($"Animal physical condition: {animal.physicalCondition}");
    Console.WriteLine($"Animal personality: {animal.personality}");
    Console.WriteLine($"Animal nickname: {animal.nickname}");
}


/// <summary>
/// Adds an animal to the animal pool
/// </summary>
void AddAnimalData()
{
    // Species
    string? speciesInput;
    bool speciesInputValid = false;

    do
    {
        Console.Write("\nEnter animal species: ");
        speciesInput = Console.ReadLine();

        if (speciesInput == null)
        {
            continue;
        }

        speciesInput = speciesInput.Trim().ToLower();

        if (speciesInput != "cat" && speciesInput != "dog")
        {
            Console.WriteLine($"\"{speciesInput}\" is not a valid animal species.");
            continue;
        }

        speciesInputValid = true;

    } while (!speciesInputValid);

    // Age
    string? ageInput;
    int age = 0;
    bool ageInputValid = false;

    do
    {
        Console.Write("Enter animal age: ");
        ageInput = Console.ReadLine();
        ageInputValid = int.TryParse(ageInput, out age);

        if (ageInputValid && age >= 0)
        {
            ageInputValid = true;
            ageInput = age.ToString();
            continue;
        }
        else if (String.IsNullOrEmpty(ageInput))
        {
            ageInputValid = true;
            continue;
        }
        else
        {
            ageInputValid = false;
        }

        Console.WriteLine($"\"{ageInput}\" is not a valid animal age.");
    } while (!ageInputValid);

    // Physical condition
    string? physicalConditionInput;
    Console.Write("Enter animal physical condition: ");
    physicalConditionInput = Console.ReadLine();

    if (String.IsNullOrEmpty(physicalConditionInput))
    {
        physicalConditionInput = "";
    }

    // Personality
    string? personalityInput;
    Console.Write("Enter animal personality: ");
    personalityInput = Console.ReadLine();

    if (String.IsNullOrEmpty(personalityInput))
    {
        personalityInput = "";
    }

    // Nickname
    string? nicknameInput;
    Console.Write("Enter animal nickname: ");
    nicknameInput = Console.ReadLine();

    if (String.IsNullOrEmpty(nicknameInput))
    {
        nicknameInput = "";
    }

    // Create new animal
    // int id = ourAnimals.Count + 1;
    int counter = 0;

    foreach (Animal animal in ourAnimals)
    {
        if (animal.species == speciesInput)
        {
            counter++;
        }
    }

    string id = speciesInput.ToUpper().Remove(1) + (counter + 1).ToString();

    Animal newAnimal = new Animal();
    newAnimal.id = id;
    newAnimal.species = speciesInput;
    newAnimal.age = ageInput;
    newAnimal.physicalCondition = physicalConditionInput;
    newAnimal.personality = personalityInput;
    newAnimal.nickname = nicknameInput;

    ourAnimals.Add(newAnimal);
}


/// <summary>
/// Gets and validates animal age input
/// </summary>
/// <returns></returns>
string GetAnimalAge()
{
    string? ageInput;
    int age = 0;
    bool ageInputValid = false;

    do
    {
        Console.Write("Enter animal age: ");
        ageInput = Console.ReadLine();

        ageInputValid = int.TryParse(ageInput, out age);

        if (ageInputValid && age >= 0)
        {
            ageInput = age.ToString();
            break;
        }
        else
        {
            ageInputValid = false;
            Console.WriteLine($"\"{ageInput}\" is not a valid animal age.");
        }

    } while (!ageInputValid);

    return ageInput;
}


/// <summary>
/// Gets and validates selected animal characteristic input
/// </summary>
/// <param name="characteristic"></param>
/// <returns></returns>
string GetAnimalOtherCharacteristics(string characteristic)
{
    string? characteristicInput;
    bool inputValid = false;

    do
    {
        Console.Write($"Enter animal {characteristic}: ");
        characteristicInput = Console.ReadLine();

        if (!String.IsNullOrEmpty(characteristicInput))
        {
            if (characteristicInput.Trim().Length > 0)
            {
                inputValid = true;
            }
        }
        
        if (!inputValid)
        {
            Console.WriteLine($"\"{characteristicInput}\" is not a valid animal {characteristic}.");
        }

    } while (!inputValid);

    return characteristicInput;
}


/// <summary>
/// Prints all animals that match the given species and physical condition
/// </summary>
/// <param name="species"></param>
/// <param name="physicalCondition"></param>
void PrintSelectedAnimals(string species, string physicalCondition)
{
    int counter = 0;

    foreach (Animal animal in ourAnimals)
    {
        if (animal.species != species)
        {
            continue;
        }

        if (animal.physicalCondition != physicalCondition)
        {
            continue;
        }

        Console.WriteLine();
        PrintAnimalData(animal);
        counter++;
    }

    if (counter <= 0)
    {
        Console.WriteLine("No animals that match the given condition.");
    }
}


/// <summary>
/// Prints all animal data in the pool
/// </summary>
void PrintAllAnimals()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    foreach (Animal animal in ourAnimals)
    {
        Console.WriteLine();
        PrintAnimalData(animal);
    }
}


/// <summary>
/// Handles adding a new batch of animals to the pool
/// </summary>
void AddAnimals()
{
    Console.WriteLine($"You can add up to {MAX_ANIMALS - ourAnimals.Count} animals.\n");
    int animalCount = 0;
    bool animalCountInputValid = false;

    do
    {
        Console.Write("Number of new animals: ");
        animalCountInputValid = int.TryParse(Console.ReadLine(), out animalCount);

        if (animalCountInputValid && animalCount > MAX_ANIMALS - ourAnimals.Count)
        {
            animalCountInputValid = false;
            Console.WriteLine($"Maximum number of animals is {MAX_ANIMALS}. The current number is {ourAnimals.Count}.");
            Console.WriteLine($"You can add up to {MAX_ANIMALS - ourAnimals.Count} animals.\n");
            continue;
        }
        else if (animalCountInputValid && animalCount == MAX_ANIMALS - ourAnimals.Count)
        {
            Console.WriteLine($"{animalCount} is the maximum number of animals that can be added right now.");
            break;
        }

        if (animalCountInputValid && animalCount > 0)
        {
            break;
        }

    } while (!animalCountInputValid);

    for (int i = 0; i < animalCount; i++)
    {
        Console.WriteLine($"\nAnimal {i + 1}");
        AddAnimalData();
    }

    PrintAllAnimals();
}


/// <summary>
/// Removes all animals from the pool
/// </summary>
void RemoveAnimals()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("Removing animal data...");
    ourAnimals.Clear();
}


/// <summary>
/// Simulates a veterinary examination
/// </summary>
void PerformVeterinaryExamination()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("Performing veterinary examination...");

    for (int i = 0; i < ourAnimals.Count; i++)
    {
        // Add age if lacking
        if (String.IsNullOrEmpty(ourAnimals[i].age))
        {
            Console.WriteLine($"\nAnimal ID: {ourAnimals[i].id}");
            Console.WriteLine($"Current animal age: {ourAnimals[i].age}");
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.age = GetAnimalAge();  
            ourAnimals[i] = currentAnimal;

            Console.WriteLine($"New animal age: {currentAnimal.age}");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        // Add physical condition if lacking
        if (String.IsNullOrEmpty(ourAnimals[i].physicalCondition))
        {
            Console.WriteLine($"\nAnimal ID: {ourAnimals[i].id}");
            Console.WriteLine($"Current animal physical condition: {ourAnimals[i].physicalCondition}");
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.physicalCondition = GetAnimalOtherCharacteristics("physical condition");
            ourAnimals[i] = currentAnimal;

            Console.WriteLine($"New animal physical condition: {currentAnimal.physicalCondition}");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    Console.WriteLine("\nAll age and physical condition data is complete.");
    Console.Write("Press Enter to continue...");
    Console.ReadLine();
}


/// <summary>
/// Allows editing animal data by the staff
/// </summary>
void EditAnimals()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("Adding lacking personality and nickname data...");

    for (int i = 0; i < ourAnimals.Count; i++)
    {
        // Add personality if lacking
        if (String.IsNullOrEmpty(ourAnimals[i].personality))
        {
            Console.WriteLine($"\nAnimal ID: {ourAnimals[i].id}");
            Console.WriteLine($"Current animal personality: {ourAnimals[i].personality}");
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.personality = GetAnimalOtherCharacteristics("personality");
            ourAnimals[i] = currentAnimal;

            Console.WriteLine($"New animal personality: {currentAnimal.personality}");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        // Add nickname if lacking
        if (String.IsNullOrEmpty(ourAnimals[i].nickname))
        {
            Console.WriteLine($"\nAnimal ID: {ourAnimals[i].id}");
            Console.WriteLine($"Current animal nickname: {ourAnimals[i].nickname}");
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.nickname = GetAnimalOtherCharacteristics("nickname");
            ourAnimals[i] = currentAnimal;

            Console.WriteLine($"New animal nickname: {currentAnimal.nickname}");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    Console.WriteLine("\nAll personality and nickname data is complete.");
    Console.Write("Press Enter to continue...");
    Console.ReadLine();

    // Further editing option
    string? decisionInput;
    Console.Write("\nDo you want to edit animal data (age and personality)? [y/n]");
    decisionInput = Console.ReadLine();

    if (String.IsNullOrEmpty(decisionInput))
    {
        return;
    }
    else if (decisionInput.Trim().ToLower() != "y")
    {
        return;
    }

    Console.WriteLine("\nEditing age and personality...");

    for (int i = 0; i < ourAnimals.Count; i++)
    {
        Console.WriteLine($"\nAnimal ID: {ourAnimals[i].id}");

        // Edit age
        Console.WriteLine($"Current animal age: {ourAnimals[i].age}");
        string newAge = GetAnimalAge();

        Console.WriteLine($"New animal age: {newAge}");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();

        // Edit personality
        Console.WriteLine($"\nCurrent animal personality: {ourAnimals[i].personality}");
        string newPersonality = GetAnimalOtherCharacteristics("personality");

        Console.WriteLine($"New animal personality: {newPersonality}");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();

        // Save animal data
        Animal currentAnimal = ourAnimals[i];
        currentAnimal.age = newAge;
        currentAnimal.personality = newPersonality;
        ourAnimals[i] = currentAnimal;
    }
}


/// <summary>
/// Displays all animals of the given species that match the given physical condition
/// </summary>
void DisplaySelectedAnimals(string species)
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine($"Displaying selected {species}s...");

    string physicalCondition = GetAnimalOtherCharacteristics("physical condition");

    PrintSelectedAnimals(species, physicalCondition);
}


/// <summary>
/// Handles the main menu
/// </summary>
void DisplayMenu()
{
    Console.WriteLine("\nWelcome to the Contoso Pets!");
    Console.WriteLine("\nMAIN MENU\n");
    Console.WriteLine("1. Show all animals [show]");
    Console.WriteLine("2. Add new animals [add]");
    Console.WriteLine("3. Perform veterinary examination [vet]");
    Console.WriteLine("4. Edit animal data [edit]");
    Console.WriteLine("5. Display selected cats [cats]");
    Console.WriteLine("6. Display selected cats [dogs]");
    Console.WriteLine("7. Remove all animals [remove]");
    Console.WriteLine("8. Exit application [exit]");
    Console.WriteLine();

    string? input;
    bool inputValid = false;

    do
    {
        Console.Write("Type option to choose: ");
        input = Console.ReadLine();

        if (input == null)
        {
            continue;
        }

        input = input.Trim().ToLower();

        switch (input)
        {
            case "show":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                PrintAllAnimals();
                DisplayMenu();
                break;
            case "add":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                AddAnimals();
                DisplayMenu();
                break;
            case "vet":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                PerformVeterinaryExamination();
                DisplayMenu();
                break;
            case "edit":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                EditAnimals();
                DisplayMenu();
                break;
            case "cats":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                DisplaySelectedAnimals("cat");
                DisplayMenu();
                break;
            case "dogs":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();
                DisplaySelectedAnimals("dog");
                DisplayMenu();
                break;
            case "remove":
                Console.WriteLine($"\nChosen option: {input}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                RemoveAnimals();
                DisplayMenu();
                break;
            case "exit":
                return;
        }

    } while (!inputValid);
}


// Application entry point
DisplayMenu();


// Animal data structure
struct Animal
{
    public string id;
    public string species;
    public string age;
    public string physicalCondition;
    public string personality;
    public string nickname;
}
