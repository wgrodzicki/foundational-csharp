using System.Diagnostics.Metrics;
using Pets.Challenge1;

namespace Pets.Challenge2
{
    public class Solution2 : Solution1
    {
        /// <summary>
        /// Handles the main menu, including the search option
        /// </summary>
        /// <returns></returns>
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
            Console.WriteLine();
            Console.WriteLine($"ID: {animal.id}");
            Console.WriteLine($"Species: {animal.species}");
            Console.WriteLine($"Age: {animal.age}");
            Console.WriteLine($"Physical condition: {animal.physicalCondition}");
            Console.WriteLine($"Personality: {animal.personality}");
            Console.WriteLine($"Nickname: {animal.nickname}");
            
            if (!String.IsNullOrEmpty(animal.suggestedDonation))
            {
                decimal donation = decimal.Parse(animal.suggestedDonation);
                Console.WriteLine($"Suggested donation: {donation:C2}");
            }
            else
            {
                Console.WriteLine($"Suggested donation: {animal.suggestedDonation}");
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
                Console.WriteLine($"\nCurrent suggested donation for the animal: {ourAnimals[i].suggestedDonation:C2}");
                string newDonation = GetAnimalSuggestedDonation();
                decimal donation = decimal.Parse(newDonation);

                Console.WriteLine($"New suggested donation for the animal: {donation:C2}");
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
            if (DisplayNoAnimalsWarning())
                return;

            string species = GetAnimalSpecies();

            string? characteristicsInput;

            do
            {
                Console.Write("Enter desired characteristics of the animal (term1, term2, term3, etc.): ");
                characteristicsInput = Console.ReadLine();
            } while (String.IsNullOrEmpty(characteristicsInput));
            
            string[] characteristicsInputSplit = characteristicsInput.Split(',');
            List<string> characteristicsCurated = new List<string>();

            // Get rid of any null/empty/whitespace only terms 
            foreach (string term in characteristicsInputSplit)
            {
                if (!String.IsNullOrWhiteSpace(term))
                {
                    characteristicsCurated.Add(term.Trim().ToLower());
                }
            }

            string[] terms = characteristicsCurated.ToArray();
            Array.Sort(terms);

            characteristicsInput = String.Join(",", terms);
            
            int animalCounter = 0;
            List<Animal> matchingAnimals = new List<Animal>();

            foreach (Animal animal in ourAnimals)
            {
                int termCounter = 0;

                if (animal.species != species)
                {
                    continue;
                }

                // Buil the characteristics string for search purposes
                string animalCharacteristics = animal.physicalCondition.Trim().ToLower() + "\n" + animal.personality.Trim().ToLower();

                foreach (string term in terms)
                {
                    PrintSearchAnimation(animal, species, term);

                    if (animalCharacteristics.Contains(term))
                    {
                        Console.WriteLine($"{char.ToUpper(species[0])}{species.Substring(1)} {animal.id} is a match for term \"{term}\"");
                        termCounter++;
                        matchingAnimals.Add(animal);
                    }
                }

                if (termCounter > 0)
                {
                    animalCounter++;
                    Console.WriteLine();
                    PrintAnimalData(animal);
                }

            }

            if (animalCounter == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"There are no {species}s that match the following characteristics: {characteristicsInput}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Animals that match at least one of the following characteristics: {characteristicsInput}");
                foreach (Animal matchingAnimal in matchingAnimals)
                {
                    PrintAnimalData(matchingAnimal);
                }
            }
        }


        /// <summary>
        /// Handles "animation" effect when searching
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="species"></param>
        /// <param name="term"></param>
        private void PrintSearchAnimation(Animal animal, string species, string term)
        {
            const int dots = 3;
            char[] animationIcons = { '2', '1', '0'};
            int waitTime = 150;

            Console.Write($"\nSearching {species} {animal.id} for term \"{term}\"... ");

            // Print icons
            for (int i = 0; i < animationIcons.Length; i++)
            {
                Console.Write(animationIcons[i]);

                // Print dots
                for (int j = 0; j < dots; j++)
                {
                    Console.Write(".");
                    Thread.Sleep(waitTime);
                }

                Thread.Sleep(waitTime);
            }
        }
    }
}