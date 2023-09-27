using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    
    private void Awake()
    {
        get = this;
    }

    // Subscribes to the OnChange events
    private void OnEnable()
    {
        Player.OnScoreChange += UpdateScore;
        Player.OnGoldChange += UpdateGold;
        Player.OnHealthChange += UpdateHealth;
        Player.OnLivesChange += UpdateLives;
        Player.OnSpeedChange += UpdateSpeed;
    }

    // Unsubscribes from the OnChange events
    private void OnDisable()
    {
        Player.OnScoreChange -= UpdateScore;
        Player.OnGoldChange -= UpdateGold;
        Player.OnHealthChange -= UpdateHealth;
        Player.OnLivesChange -= UpdateLives;
        Player.OnSpeedChange -= UpdateSpeed;
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
