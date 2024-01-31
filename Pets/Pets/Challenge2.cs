using System.Diagnostics.Metrics;
using Pets.Challenge1;

namespace Pets.Challenge2
{
    public class Solution2 : Solution1
    {
        public override bool DisplayMenu()
        {
            Console.WriteLine("\nWelcome to the Contoso Pets!");

            string? input;
            bool appRunning = true;

            do
            {
                Console.WriteLine("\nMAIN MENU\n");
                Console.WriteLine("1. Show all animals [show]");
                Console.WriteLine("2. Add new animals [add]");
                Console.WriteLine("3. Perform veterinary examination [vet]");
                Console.WriteLine("4. Edit animal data [edit]");
                Console.WriteLine("5. Display selected cats [cats]");
                Console.WriteLine("6. Display selected cats [dogs]");
                Console.WriteLine("7. Search for specific animals [search]");
                Console.WriteLine("8. Remove all animals [remove]");
                Console.WriteLine("9. Exit application [exit]");
                Console.WriteLine();

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
                        break;
                    case "add":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        AddAnimals();
                        break;
                    case "vet":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        PerformVeterinaryExamination();
                        break;
                    case "edit":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        EditAnimals();
                        break;
                    case "cats":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        DisplaySelectedAnimals("cat");
                        break;
                    case "dogs":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        DisplaySelectedAnimals("dog");
                        break;
                    case "search":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine();
                        SearchAnimals();
                        break;
                    case "remove":
                        Console.WriteLine($"\nChosen option: {input}");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        RemoveAnimals();
                        break;
                    case "exit":
                        return false;
                }

            } while (appRunning);

            return appRunning;
        }

        
        /// <summary>
        /// Prints selected animal data, including suggested donation
        /// </summary>
        /// <param name="animal"></param>
        protected override void PrintAnimalData(Animal animal)
        {
            Console.WriteLine($"Animal ID: {animal.id}");
            Console.WriteLine($"Animal species: {animal.species}");
            Console.WriteLine($"Animal age: {animal.age}");
            Console.WriteLine($"Animal physical condition: {animal.physicalCondition}");
            Console.WriteLine($"Animal personality: {animal.personality}");
            Console.WriteLine($"Animal nickname: {animal.nickname}");
            
            if (!String.IsNullOrEmpty(animal.suggestedDonation))
            {
                decimal donation = decimal.Parse(animal.suggestedDonation);
                Console.WriteLine($"Suggested donation for the animal: {donation:C}");
            }
            else
            {
                Console.WriteLine($"Suggested donation for the animal: {animal.suggestedDonation}");
            }
        }


        /// <summary>
        /// Adds an animal to the animal pool, including suggested donation
        /// </summary>
        protected override void AddAnimalData()
        {
            // Species
            string speciesInput = GetAnimalSpecies();

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

            // Suggested donation
            string? donationInput;
            decimal donation = 0.0m;
            bool donationInputValid = false;

            do
            {
                Console.Write("Enter suggested donation for the animal: ");
                donationInput = Console.ReadLine();
                donationInputValid = decimal.TryParse(donationInput, out donation);

                if (donationInputValid && donation >= 0)
                {
                    donationInputValid = true;
                    donationInput = donation.ToString();
                    continue;
                }
                else if (String.IsNullOrEmpty(donationInput))
                {
                    donationInputValid = true;
                    continue;
                }
                else
                {
                    donationInputValid = false;
                }

                Console.WriteLine($"\"{donationInput}\" is not a valid suggested donation value.");
            } while (!donationInputValid);

            // Create new animal
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
            newAnimal.suggestedDonation = donationInput;

            ourAnimals.Add(newAnimal);
        }
        

        /// <summary>
        /// Allows editing animal data by the staff, including suggested donation
        /// </summary>
        protected override void EditAnimals()
        {
            if(DisplayNoAnimalsWarning())
                return;

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
            Console.Write("\nDo you want to edit animal data (age, personality, suggested donation)? [y/n]");
            decisionInput = Console.ReadLine();

            if (String.IsNullOrEmpty(decisionInput))
            {
                return;
            }
            else if (decisionInput.Trim().ToLower() != "y")
            {
                return;
            }

            Console.WriteLine("\nEditing age, personality, suggested donation...");

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

                // Edit suggested donation
                Console.WriteLine($"\nCurrent suggested donation for the animal: {ourAnimals[i].suggestedDonation:C}");
                string newDonation = GetAnimalSuggestedDonation();
                decimal donation = decimal.Parse(newDonation);

                Console.WriteLine($"New suggested donation for the animal: {donation:C}");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();

                // Save animal data
                Animal currentAnimal = ourAnimals[i];
                currentAnimal.age = newAge;
                currentAnimal.personality = newPersonality;
                currentAnimal.suggestedDonation = newDonation;
                ourAnimals[i] = currentAnimal;
            }
        }


        /// <summary>
        /// Gets and validates suggested donation input
        /// </summary>
        /// <returns></returns>
        private string GetAnimalSuggestedDonation()
        {
            string? donationInput;
            decimal donation = 0.0m;
            bool donationInputValid = false;

            do
            {
                Console.Write("Enter suggested donation for the animal: ");
                donationInput = Console.ReadLine();
                donationInputValid = decimal.TryParse(donationInput, out donation);

                if (donationInputValid && donation >= 0)
                {
                    donationInputValid = true;
                    donationInput = donation.ToString();
                }
                else
                {
                    donationInputValid = false;
                    Console.WriteLine($"\"{donationInput}\" is not a valid suggested donation value.");
                }
            } while (!donationInputValid);

            return donationInput;
        }


        /// <summary>
        /// Displays animals that match the given characteristics in terms of physical condition and/or personality
        /// </summary>
        private void SearchAnimals()
        {
            if(DisplayNoAnimalsWarning())
                return;

            string species = GetAnimalSpecies();

            string? characteristicsInput;

            do
            {
                Console.Write("Characteristics of the animal to search for: ");
                characteristicsInput = Console.ReadLine();
            } while (String.IsNullOrEmpty(characteristicsInput)); 

            characteristicsInput = characteristicsInput.Trim().ToLower();
            int counter = 0;

            foreach (Animal animal in ourAnimals)
            {
                if (animal.species != species)
                {
                    continue;
                }

                string animalCharacteristics = animal.physicalCondition + " " + animal.personality;

                if (animalCharacteristics.Contains(characteristicsInput))
                {
                    if (counter == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Animals that match the following characteristics: {characteristicsInput}");
                    }
                    counter++;
                    Console.WriteLine();
                    PrintAnimalData(animal);
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"No animals that match the following characteristics: {characteristicsInput}");
            }
        }
    }
}