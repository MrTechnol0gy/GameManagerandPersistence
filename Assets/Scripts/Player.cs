using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This class manages the player's information
    public static Player get;
    // Header("Player Stats") makes the variables below this line show up in the inspector under the header
    [Header("Player Stats")]
    public int score = 0;
    public int health = 21;
    public int lives = 3;
    public int gold = 0;
    public float speed = 1.0f;

    // delegates and events
    public delegate void GoldEventHandler();
    public static event GoldEventHandler OnGoldChange;
    public delegate void ScoreEventHandler();
    public static event ScoreEventHandler OnScoreChange;
    public delegate void HealthEventHandler();
    public static event HealthEventHandler OnHealthChange;
    public delegate void LivesEventHandler();
    public static event LivesEventHandler OnLivesChange;
    public delegate void SpeedEventHandler();
    public static event SpeedEventHandler OnSpeedChange;
    
    private void Awake()
    {
        get = this;
    }
    
    // increments the score by 1
    public void IncrementScore()
    {
        score++;
        if (OnScoreChange != null)
        {
            OnScoreChange();
        }
    }
    // increments the gold by 1
    public void IncrementGold()
    {
        gold++;
        if (OnGoldChange != null)
        {
            OnGoldChange();
        }
    }
    // increments the lives by 1
    public void IncrementLives()
    {
        lives++;
        if (OnLivesChange != null)
        {
            OnLivesChange();
        }
    }
    // increments the health by 1
    public void IncrementHealth()
    {
        health++;
        if (OnHealthChange != null)
        {
            OnHealthChange();
        }
    }
    // increases the speed by 0.5f
    public void IncrementSpeed()
    {
        speed += 0.5f;
        if (OnSpeedChange != null)
        {
            OnSpeedChange();
        }
    }
    // decrements the score by 1
    public void DecrementScore()
    {
        score--;
        if (OnScoreChange != null)
        {
            OnScoreChange();
        }
    }
    // decrements the health by 1
    public void DecrementHealth()
    {
        health--;
        if (OnHealthChange != null)
        {
            OnHealthChange();
        }
    }
    // decrements the lives by 1
    public void DecrementLives()
    {
        lives--;
        if (OnLivesChange != null)
        {
            OnLivesChange();
        }
    }
    // decrements the gold by 1
    public void DecrementGold()
    {
        gold--;
        if (OnGoldChange != null)
        {
            OnGoldChange();
        }
    }
    // decreases the speed by 0.5f
    public void DecrementSpeed()
    {
        speed -= 0.5f;
        if (OnSpeedChange != null)
        {
            OnSpeedChange();
        }
    }
}
