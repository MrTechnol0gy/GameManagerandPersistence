using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager get;
    
    // References to the text UI elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI saveTimeText;
    public TextMeshProUGUI instanceCountText;

    // References to the UI buttons
    public Button saveButton;
    public Button loadButton;
    public Button quitButton;
    public Button mainMenuButton;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button healthIncrementButton;
    public Button speedIncrementButton;
    public Button livesIncrementButton;
    public Button goldIncrementButton;
    public Button scoreIncrementButton;
    public Button healthDecrementButton;
    public Button speedDecrementButton;
    public Button livesDecrementButton;
    public Button goldDecrementButton;
    public Button scoreDecrementButton;

    private GameObject sceneObjects;
    private void Awake()
    {
        get = this;
        //Debug.Log("UIManager Awake");
    }

    private void Start()
    {     
        // find the new scene objects
        sceneObjects = GameObject.Find("SceneObjects");

        // find and assign each UI text element
        AssignUITextElements();

        // find and assign each UI button
        AssignUIButtons();

        // set the buttons
        SetButtons();
    }

    private void Update()
    {
        // Update All UI Text
        UpdateScore();
        UpdateGold();
        UpdateHealth();
        UpdateLives();
        UpdateSpeed();   
        UpdateInstanceCount();     
    }

    // Subscribes to the OnChange events
    private void OnEnable()
    {
        Debug.Log("UIManager OnEnable");
        Player.OnScoreChange += UpdateScore;
        Player.OnGoldChange += UpdateGold;
        Player.OnHealthChange += UpdateHealth;
        Player.OnLivesChange += UpdateLives;
        Player.OnSpeedChange += UpdateSpeed;
    }

    // Unsubscribes from the OnChange events
    public void OnDisable()
    {
        Debug.Log("UIManager OnDisable");
        Player.OnScoreChange -= UpdateScore;
        Player.OnGoldChange -= UpdateGold;
        Player.OnHealthChange -= UpdateHealth;
        Player.OnLivesChange -= UpdateLives;
        Player.OnSpeedChange -= UpdateSpeed;
    }

    // When a new scene is loaded, find the UI text elements
    private void AssignUITextElements()
    {
        // find and assign each UI text element
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        goldText = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        speedText = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        saveTimeText = GameObject.Find("Save Time").GetComponent<TextMeshProUGUI>();
        instanceCountText = GameObject.Find("Instance Count").GetComponent<TextMeshProUGUI>();
    }

    private void AssignUIButtons()
    {
        // find and assign each UI button
        saveButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/Save Game").GetComponent<Button>();
        loadButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/Load Game").GetComponent<Button>();
        quitButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/Quit").GetComponent<Button>();
        mainMenuButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/SceneSelection/MainMenu").GetComponent<Button>();
        level1Button = sceneObjects.transform.Find("Canvas/MainMenuPanel/SceneSelection/Level One").GetComponent<Button>();
        level2Button = sceneObjects.transform.Find("Canvas/MainMenuPanel/SceneSelection/Level Two").GetComponent<Button>();
        level3Button = sceneObjects.transform.Find("Canvas/MainMenuPanel/SceneSelection/Level Three").GetComponent<Button>();
        healthIncrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Increment Health").GetComponent<Button>();
        speedIncrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Increment Speed").GetComponent<Button>();
        livesIncrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Increment Lives").GetComponent<Button>();
        goldIncrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Increment Gold").GetComponent<Button>();
        scoreIncrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Increment Score").GetComponent<Button>();
        healthDecrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Decrement Health").GetComponent<Button>();
        speedDecrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Decrement Speed").GetComponent<Button>();
        livesDecrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Decrement Lives").GetComponent<Button>();
        goldDecrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Decrement Gold").GetComponent<Button>();
        scoreDecrementButton = sceneObjects.transform.Find("Canvas/MainMenuPanel/PlayerButtons/Decrement Score").GetComponent<Button>();
    }

    // When a new scene is loaded, drop the previous UI assignments and reassign them
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Reconnect");

        // find the new scene objects
        sceneObjects = GameObject.Find("SceneObjects");

        // find and assign each UI text element
        AssignUITextElements();

        // find and assign each UI button
        AssignUIButtons();

        // set the buttons
        SetButtons();      
    }

    // Sets the buttons
    private void SetButtons()
    {
        healthIncrementButton.onClick.AddListener(Player.get.IncrementHealth);
        speedIncrementButton.onClick.AddListener(Player.get.IncrementSpeed);
        livesIncrementButton.onClick.AddListener(Player.get.IncrementLives);
        goldIncrementButton.onClick.AddListener(Player.get.IncrementGold);
        scoreIncrementButton.onClick.AddListener(Player.get.IncrementScore);
        healthDecrementButton.onClick.AddListener(Player.get.DecrementHealth);
        speedDecrementButton.onClick.AddListener(Player.get.DecrementSpeed);
        livesDecrementButton.onClick.AddListener(Player.get.DecrementLives);
        goldDecrementButton.onClick.AddListener(Player.get.DecrementGold);
        scoreDecrementButton.onClick.AddListener(Player.get.DecrementScore);        
        mainMenuButton.onClick.AddListener(GameManager.get.LoadMainMenu);
        quitButton.onClick.AddListener(GameManager.get.QuitGame);
        level1Button.onClick.AddListener(GameManager.get.LoadLevel1);
        level2Button.onClick.AddListener(GameManager.get.LoadLevel2);
        level3Button.onClick.AddListener(GameManager.get.LoadLevel3);
        saveButton.onClick.AddListener(GameManager.get.SaveGame);
        loadButton.onClick.AddListener(GameManager.get.LoadGame);
    }

    // Updates the score text
    public void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Player.get.score;
        }
        else
        {
            Debug.Log("Score Text is null");
        }
    }

    // Updates the gold text
    public void UpdateGold()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + Player.get.gold;
        }
        else
        {
            Debug.Log("Gold Text is null");
        }
    }

    // Updates the health text
    public void UpdateHealth()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + Player.get.health;
        }
        else
        {
            Debug.Log("Health Text is null");
        }
    }

    // Updates the lives text
    public void UpdateLives()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + Player.get.lives;
        }
        else
        {
            Debug.Log("Lives Text is null");
        }
    }

    // Updates the speed text
    public void UpdateSpeed()
    {
        if (speedText != null)
        {
            speedText.text = "Speed: " + Player.get.speed;
        }
        else
        {
            Debug.Log("Speed Text is null");
        }
    }

    // Updates the instance count text
    public void UpdateInstanceCount()
    {
        if (instanceCountText != null)
        {
            instanceCountText.text = "Instance Count: " + GameManager.get.GetInstanceCount();
        }
        else
        {
            Debug.Log("Instance Count Text is null");
        }
    }

    // Updates the Save Time text
    public void UpdateSaveTime()
    {
        // if (saveTimeText != null)
        // {
        //     saveTimeText.text = "Last Saved: " + Player.get.saveTime;
        // }
        // else
        // {
        //     Debug.Log("Save Time Text is null");
        // }
    }
}
