/*
Contoso Pets application, an application that helps place pets in new homes.
*/

List<Animal> ourAnimals = new List<Animal>();
int animalCount = 0;


void PrintAnimalData(Animal animal)
{
    Console.WriteLine($"Animal id: {animal.id}");
    Console.WriteLine($"Animal species: {animal.species}");
    Console.WriteLine($"Animal age: {animal.age}");
    Console.WriteLine($"Animal physical condition: {animal.physicalCondition}");
    Console.WriteLine($"Animal personality: {animal.personality}");
    Console.WriteLine($"Animal nickname: {animal.nickname}");
}


void AddAnimalData()
{
    string? speciesInput;
    bool speciesInputValid = false;

    do
    {
        Console.Write("Enter animal species: ");
        speciesInput = Console.ReadLine();

        if (speciesInput == null)
        {
            continue;
        }

        speciesInput = speciesInput.Trim().ToLower();

        if (speciesInput != "cat" && speciesInput != "dog")
        {
            Console.WriteLine("Invalid species \"{speciesInput\"");
            continue;
        }

        speciesInputValid = true;

    } while (!speciesInputValid);

    int age = 0;
    bool ageInputValid = false;
    
    Console.Write("Enter animal age: ");
    ageInputValid = int.TryParse(Console.ReadLine(), out age);

    string? physicalConditionInput;
    string? personalityInput;
    string? nicknameInput;

    Console.Write("Enter animal physical condition: ");
    physicalConditionInput = Console.ReadLine();

    if (String.IsNullOrEmpty(physicalConditionInput))
    {
        physicalConditionInput = "";
    }

    Console.Write("Enter animal personality: ");
    personalityInput = Console.ReadLine();

    if (String.IsNullOrEmpty(personalityInput))
    {
        personalityInput = "";
    }

    Console.Write("Enter animal nickname: ");
    nicknameInput = Console.ReadLine();

    if (String.IsNullOrEmpty(nicknameInput))
    {
        nicknameInput = "";
    }

    int id = ourAnimals.Count + 1;
    Animal animal = new Animal();
    animal.id = id;
    animal.species = speciesInput;
    animal.age = age;
    animal.physicalCondition = physicalConditionInput;
    animal.personality = personalityInput;
    animal.nickname = nicknameInput;
    
    ourAnimals.Add(animal);
}


void RemoveAnimalData()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    ourAnimals.Clear();
}


int GetAnimalAge()
{
    string? ageInput;
    int age = 0;
    bool ageInputValid = false;

    do
    {
        Console.Write("Enter animal age: ");
        ageInput = Console.ReadLine();

        ageInputValid = int.TryParse(ageInput, out age);

        if (ageInputValid && age > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine($"\"{age}\" is not a valid animal age.");
        }

    } while (!ageInputValid);

    return age;
}


// Ensure animal nicknames, physical description and personality descriptions are complete (this action can occur after the team gets to know a pet).
string GetAnimalOtherCharacteristics(string characteristic)
{
    string? characteristicInput;
    bool inputValid = false;

    do
    {
        Console.Write("Enter animal {characteristic}: ");
        characteristicInput = Console.ReadLine();

        if (characteristicInput != null)
        {
            inputValid = true;
        }

    } while (!inputValid);

    return characteristicInput;
}


void PrintSelectedAnimals(string species, string physicalCondition)
{
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

        PrintAnimalData(animal);
    }
}

void AddAnimals()
{
    bool animalCountInputValid = false;

    do
    {
        Console.Write("Number of new animals: ");
        animalCountInputValid = int.TryParse(Console.ReadLine(), out animalCount);

        if (animalCountInputValid && animalCount > 0)
        {
            break;
        }

    } while (!animalCountInputValid);

    for (int i = 0; i < animalCount; i++)
    {
        Console.WriteLine($"\nAnimal {i}");
        AddAnimalData();
    }

    for (int i = 0; i < animalCount; i++)
    {
        Console.WriteLine($"\nAnimal {i}");
        PrintAnimalData(ourAnimals[i]);
    }
}


void PerformVeterinaryExamination()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("\nAPerforming a veterinary examination...");

    for (int i = 0; i < animalCount; i++)
    {
        if (ourAnimals[i].age == 0)
        {
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.age = GetAnimalAge();
            ourAnimals[i] = currentAnimal;
        }

        if (String.IsNullOrEmpty(ourAnimals[i].physicalCondition))
        {
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.physicalCondition = GetAnimalOtherCharacteristics("physical condition");
            ourAnimals[i] = currentAnimal;
        }
    }
}   


void EditAnimals()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("\nAfter the team gets to know the pet...");

    for (int i = 0; i < ourAnimals.Count; i++)
    {
        if (String.IsNullOrEmpty(ourAnimals[i].personality))
        {
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.personality = GetAnimalOtherCharacteristics("personality");
            ourAnimals[i] = currentAnimal;
        }

        if (String.IsNullOrEmpty(ourAnimals[i].nickname))
        {
            Animal currentAnimal = ourAnimals[i];
            currentAnimal.nickname = GetAnimalOtherCharacteristics("nickname");
            ourAnimals[i] = currentAnimal;
        }
    }

    Console.WriteLine("\nEditing age and personality...");

    for (int i = 0; i < ourAnimals.Count; i++)
    {
        int newAge = GetAnimalAge();
        string newPersonality = GetAnimalOtherCharacteristics("personality");
        Animal currentAnimal = ourAnimals[i];
        currentAnimal.age = newAge;
        currentAnimal.personality = newPersonality;
        ourAnimals[i] = currentAnimal;
    }
}


void DisplaySelectedCats()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("\nDisplaying selected cats...");

    for (int i = 0; i < animalCount; i++)
    {
        string species = "cat";
        string physicalCondition = GetAnimalOtherCharacteristics("physical condition");
        PrintSelectedAnimals(species, physicalCondition);
    }
}


void DisplaySelectedDogs()
{
    if (ourAnimals.Count <= 0)
    {
        Console.WriteLine("There are no animals!");
        return;
    }

    Console.WriteLine("\nDisplaying selected dogs...");

    for (int i = 0; i < animalCount; i++)
    {
        string species = "dog";
        string physicalCondition = GetAnimalOtherCharacteristics("physical condition");
        PrintSelectedAnimals(species, physicalCondition);
    }
}


void DisplayMenu()
{
    Console.WriteLine("Menu");
    Console.WriteLine("Add new animals [add]");
    Console.WriteLine("Perform veterinary examination [vet]");
    Console.WriteLine("Edit animal personality and nicknames [edit]");
    Console.WriteLine("Display selected cats [cats]");
    Console.WriteLine("Display selected cats [dogs]");
    Console.WriteLine("Remove all animals [remove]");
    Console.WriteLine("Exit application [exit]");
    Console.Write("Option: ");

    string? input;
    bool inputValid = false;

    do
    {
        input = Console.ReadLine();

        if (input == null)
        {
            continue;
        }

        input = input.Trim().ToLower();

        switch (input)
        {
            case "add":
                AddAnimals();
                DisplayMenu();
                break;
            case "vet":
                PerformVeterinaryExamination();
                DisplayMenu();
                break;
            case "edit":
                EditAnimals();
                DisplayMenu();
                break;
            case "cats":
                DisplaySelectedCats();
                DisplayMenu();
                break;
            case "dogs":
                DisplaySelectedDogs();
                DisplayMenu();
                break;
            case "remove":
                RemoveAnimalData();
                DisplayMenu();
                break;
            case "exit":
                return;
        }

    } while (!inputValid);
}

// APPLICATION ENTRY POINT
DisplayMenu();


struct Animal
{
    public int id;
    public string species;
    public int age;
    public string physicalCondition;
    public string personality;
    public string nickname;
}





