using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager get;

    // Goes to the Main Menu scene
    public void GoToMainMenu()
    {
        // if the current scene is already the main menu, do nothing
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    // Goes to the Level One Scene
    public void GoToLevelOne()
    {
        // if the current scene is already level one, do nothing
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
    // Goes to the Level Two Scene
    public void GoToLevelTwo()
    {
        // if the current scene is already level two, do nothing
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("LevelTwo");
        }
    }
    // Goes to the Level Three Scene
    public void GoToLevelThree()
    {
        // if the current scene is already level three, do nothing
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("LevelThree");
        }
    }
    // Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
