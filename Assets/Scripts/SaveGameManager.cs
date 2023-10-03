using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameManager : MonoBehaviour
{
    // This class manages saving and loading the player information between sessions

    public static SaveGameManager get;
    private PlayerData data;

    private void Awake()
    {
        // Singleton
        if (get == null)
        {
            get = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        // This line creates a new PlayerData object
        // This object will hold the data we want to save
        data = new PlayerData();
    }
    // This method saves the players information
    public void SavePlayerData(int score, int health, int lives, int gold, float speed)
    {
        // This line creates a new BinaryFormatter
        // A binary formatter is used to serialize and deserialize data
        BinaryFormatter bf = new BinaryFormatter();
        if (bf == null)
        {
            Debug.Log("BinaryFormatter is null");
            return;
        }

        // This line creates a new FileStream
        // A file stream is used to read and write data to a file
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        
        if (file == null)
        {
            Debug.Log("File is null");
            return;
        }
        // This line creates a new PlayerData object
        // This object will hold the data we want to save

        // This line sets the data in the PlayerData object
        data.score = score;
        data.health = health;
        data.lives = lives;
        data.gold = gold;
        data.speed = speed;
        data.saveTime = System.DateTime.Now.ToString();

        // This line serializes the PlayerData object
        // Serialization is the process of converting an object into a stream of bytes
        bf.Serialize(file, data);

        // This line closes the file stream
        file.Close();
    }

    // This method loads the players information
    public PlayerData LoadPlayerData()
    {
        // This line checks if the file exists
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            // This line creates a new BinaryFormatter
            // A binary formatter is used to serialize and deserialize data
            BinaryFormatter bf = new BinaryFormatter();

            // This line creates a new FileStream
            // A file stream is used to read and write data to a file
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            // This line deserializes the PlayerData object
            // Deserialization is the process of converting a stream of bytes into an object
            data = (PlayerData)bf.Deserialize(file);

            // This line closes the file stream
            file.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not exist!");
            return null;
        }
    }

    // This method returns the PlayerData object
    public PlayerData PlayerData
    {
        get
        {
            return data;
        }
    }
}

// This class holds the data we want to save
[System.Serializable]
public class PlayerData
{
    public int score;
    public int health;
    public int lives;
    public int gold;
    public float speed;
    public string saveTime;
}
