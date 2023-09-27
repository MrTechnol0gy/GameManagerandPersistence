using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This class manages the player's information
    public static Player get;
    // Header("Player Stats") makes the variables below this line show up in the inspector under the header
    [Header("Player Stats")]
    public int score;
    public int health;
    public int lives;
    public int gold;
    public float speed;
    
    // increments the score by 1
    public void IncrementScore()
    {
        score++;
    }
    // increments the gold by 1
    public void IncrementGold()
    {
        gold++;
    }
    // increments the lives by 1
    public void IncrementLives()
    {
        lives++;
    }
    // increments the health by 1
    public void IncrementHealth()
    {
        health++;
    }
    // increases the speed by 0.5f
    public void IncreaseSpeed()
    {
        speed += 0.5f;
    }
    // decrements the score by 1
    public void DecrementScore()
    {
        score--;
    }
    // decrements the health by 1
    public void DecrementHealth()
    {
        health--;
    }
    // decrements the lives by 1
    public void DecrementLives()
    {
        lives--;
    }
    // decrements the gold by 1
    public void DecrementGold()
    {
        gold--;
    }
    // decreases the speed by 0.5f
    public void DecreaseSpeed()
    {
        speed -= 0.5f;
    }
}
