using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
public class saveSystem : MonoBehaviour
{
    private polarityChanger[] Polarity;
    private string saveLocation;
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        LoadGame();
    }

    public void SaveGame()
    {
        saveData SaveData = new saveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position
        };

        File.WriteAllText(saveLocation,JsonUtility.ToJson(SaveData));
    }


    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
           saveData saveData = JsonUtility.FromJson<saveData>(File.ReadAllText(saveLocation));

           GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
        }
        else
        {
            SaveGame();
        }
    }
}
