﻿using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = {"('-')", "(^-^)", "(X_X)"};
string[] foods = {"@@@@@", "$$$$$", "#####"};

string currentFood = "";

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();

while (!shouldExit) 
{
    if (TerminalResized())
    {
        Console.Clear();
        Console.WriteLine("Console was resized. Program exiting.");
        break;
    }

    if (CheckFastState())
    {
        Move(true, speedChange: 3);
    }
    else
    {
        Move(true);
    }
    
    if (CheckFoodConsumed())
    {
        ChangePlayer();
        ShowFood();

        if (CheckFreezeState())
            FreezePlayer();
    }
}

// Returns true if the Terminal was resized 
bool TerminalResized() 
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood() 
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer() 
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Checks if the player is in the "fast state"
bool CheckFastState()
{
    if (player == states[1])
        return true;
    else
        return false;
}

// Temporarily stops the player from moving
void FreezePlayer() 
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Checks if the player is in the "freeze state"
bool CheckFreezeState()
{
    if (player == states[2])
        return true;
    else
        return false;
}

// Checks whether the player has consumed all food visible
bool CheckFoodConsumed()
{
    if (playerY != foodY)
        return false;
    
    // Check if any food fragment is consumed by the player
    for (int i = 0; i < foods[food].Length; i++)
    {
        // Bypass fragment if already consumed
        if (String.IsNullOrWhiteSpace(foods[food][i].ToString()))
        {
            continue;
        }

        if ((foodX + i) >= playerX && (foodX + i) <= (playerX + player.Length - 1))
        {
            // Build the current food placeholder
            currentFood += foods[food][i];

            // Swap the current food fragment for an empty string
            string updatedFood = foods[food].Remove(i, 1);
            updatedFood = updatedFood.Insert(i, " ");
            foods[food] = updatedFood;
        }

        // Whole food consumed
        if (String.IsNullOrWhiteSpace(foods[food]))
        {
            // Rebuild the current food string and reset placeholder
            foods[food] = currentFood;
            currentFood = "";
            return true;
        }
    }
    return false;
}

// Reads directional input from the Console and moves the player
void Move(bool terminateOnNonDirectional = false, int speedChange = 1) 
{
    int lastX = playerX;
    int lastY = playerY;
    
    switch (Console.ReadKey(true).Key) 
    {
        case ConsoleKey.UpArrow:
            playerY--; 
            break;
		case ConsoleKey.DownArrow: 
            playerY++; 
            break;
		case ConsoleKey.LeftArrow:  
            playerX -= speedChange; 
            break;
		case ConsoleKey.RightArrow: 
            playerX += speedChange; 
            break;
		case ConsoleKey.Escape:     
            shouldExit = true; 
            break;
        default:
            if (terminateOnNonDirectional)
            {
                Console.Clear();
                shouldExit = true;
                return;
            }
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++) 
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame() 
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}