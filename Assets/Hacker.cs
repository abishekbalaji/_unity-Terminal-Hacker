using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    string org;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to hack?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection...");
    }
    void OnUserInput(string input)
    {
        if (input == "menu") ShowMainMenu();
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPasswordMenu(input);
        }


    }

    void RunPasswordMenu(string input)
    {
        Terminal.ClearScreen();
        if (input == password)
        {
            Terminal.WriteLine("You have successfully hacked " + org + "!!!");
            WinMenu();
        } else
        {
            Terminal.WriteLine("Incorrect password!");
            StartGame();
        }
    }

    void WinMenu()
    {
        
        currentScreen = Screen.Win;
        Terminal.WriteLine("You are a real hacker dude!!! Well done bruh!!!");
    }

    void RunMainMenu(string input)
    {
        if (input == "007") Terminal.WriteLine("Please select a level Mr. Bond");
        else if (input == "1")
        {
            level = 1;
            password = "hacklib";
            org = "your local library";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "hackpoli";
            org = "your local police station";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "hacknasa";
            org = "NASA";
            StartGame();
        }
        else Terminal.WriteLine("Please enter a valid level!");
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter the password...");
        currentScreen = Screen.Password;
    }
}
