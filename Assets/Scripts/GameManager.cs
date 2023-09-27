using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager get;

    private void Awake()
    {
        get = this;
    }
    // Goes to the Main Menu scene
    public void LoadMainMenu()
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
    public void LoadLevel1()
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
    public void LoadLevel2()
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
    public void LoadLevel3()
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

    // Calls the SaveGameManager to save the game
    public void SaveGame()
    {
        if (Player.get == null)
        {
            Debug.Log("Player is null");
            return;
        }
        if (SaveGameManager.get == null)
        {
            Debug.Log("SaveGameManager is null");
            return;
        }
        SaveGameManager.get.SavePlayerData(Player.get.score, Player.get.health, Player.get.lives, Player.get.gold, Player.get.speed);
    }

    // Calls the SaveGameManager to load the game
    public void LoadGame()
    { 
        PlayerData playerData = SaveGameManager.get.LoadPlayerData();

        // Assigns the data to the player
        Player.get.score = playerData.score;
        Player.get.health = playerData.health;
        Player.get.lives = playerData.lives;
        Player.get.gold = playerData.gold;
        Player.get.speed = playerData.speed;
        
    }
    // Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
