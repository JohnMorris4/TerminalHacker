using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Config
    const string menuHint = "You may type menu at anytime to return to the main menu";
    private string[] passwordLevel1 = {"books", "shelf", "dewey", "font", "aisle"};
    private string[] passwordLevel2 = {"ticket", "uniform", "pistol", "arrest", "handcuffs"};
    private string[] passwordLevel3 = {"telescope", "astronauts", "spaceforce", "atmosphere", "starfield"};    
    
    // Start is called before the first frame update
    //Game State
    int _level;
    enum Screen { MainMenu, Password, Win }

    private string password;
    
    Screen _currentScreen = Screen.MainMenu;
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
       

        
    }

    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            _currentScreen = Screen.MainMenu;
            ShowMainMenu();
        } 
        else if(_currentScreen == Screen.MainMenu)

        {
            RunMainMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
            
        
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            _level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "cia")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("+++");
            Terminal.WriteLine("Please choose a level Mr Spy");
            _currentScreen = Screen.MainMenu;
        }
        else
        {
            Terminal.WriteLine("Please choose a correct level");
            Terminal.WriteLine(menuHint);
            //_currentScreen = Screen.MainMenu;
        }
    }


    void AskForPassword()
    {
        _currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter your password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (_level)
        {
            case 1:
                password = passwordLevel1[Random.Range(0, passwordLevel1.Length)];
                break;
            case 2:
                password = passwordLevel2[Random.Range(0, passwordLevel2.Length)];
                break;
            case 3:
                password = passwordLevel3[Random.Range(0, passwordLevel3.Length)];
                break;
            default:
                Debug.LogError("Invalid response");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (_level)
        {
            case 1:
                Terminal.WriteLine("Congratulations you solved the password for level 1");
                
                break;
            case 2:
                Terminal.WriteLine("Congratulations you solved the password for level 2");
                break;
            case 3:
                Terminal.WriteLine("Congratulations you solved the password for level 3");
                break;
            default:
                break;
        }
       
    }
}
