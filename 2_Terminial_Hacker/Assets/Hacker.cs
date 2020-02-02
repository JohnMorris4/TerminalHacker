using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    //Game State
    int _level;
    void Start()
    {
       
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
        //OnUserInput();

        
    }

    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "1")
        {
            _level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            _level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            _level = 3;
            StartGame();
        }
        else if (input == "cia" )
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("+++");
            Terminal.WriteLine("Please choose a level Mr Spy");
        }
        else
        {
            Terminal.WriteLine("Please choose a correct level");
        }
        
        
    }

    void StartGame()
    {
        Terminal.WriteLine($"You have chosen level {_level}");
    }
}
