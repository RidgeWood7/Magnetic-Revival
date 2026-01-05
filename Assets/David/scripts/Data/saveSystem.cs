using UnityEngine;
using System.IO;

using UnityEditor;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class saveSystem : MonoBehaviour
{
    private polarityChanger[] Polarity;
    private string saveLocation;
    private string saveCameraLocation;


    void Start()
    {
        InitializeComponents();

        LoadGame();

       
    }

    private void InitializeComponents()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json"); 
        Polarity = FindObjectsByType<polarityChanger>(FindObjectsSortMode.None);
    }

    public void SaveGame()
    {
        saveData SaveData = new saveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            polaritySavedata = GetPolarityChangersState(),
            playerPolarity = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Magnet>()._polarity,
        };

        File.WriteAllText(saveLocation,JsonUtility.ToJson(SaveData));
    }

    

    public void LoadGame()
    {

        if (File.Exists(saveLocation))
        {
           saveData saveData = JsonUtility.FromJson<saveData>(File.ReadAllText(saveLocation));

           GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

           GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Magnet>()._polarity = saveData.playerPolarity;

            

            LoadPolartityState(saveData.polaritySavedata);
        }
        else
        {
            SaveGame();
        }
    }


    private List<polaritySavedata> GetPolarityChangersState()
    {
        List<polaritySavedata> polarityStates = new List<polaritySavedata>();
        
        foreach ( polarityChanger polarityChanger in Polarity)
        {
            polaritySavedata polaritysavedata = new polaritySavedata()
            {
                polarityId = polarityChanger.Changerid,
                isUsed = !polarityChanger.isOpened

            };
            polarityStates.Add(polaritysavedata);
        }
        
        return polarityStates;
    }


    private void LoadPolartityState(List<polaritySavedata> polarityStates)
    {
        foreach(polarityChanger polaritychanger in Polarity)
        {
            polaritySavedata polaritySaveData = polarityStates.FirstOrDefault(p => p.polarityId == polaritychanger.Changerid);

            if (polaritySaveData != null)
            {
                polaritychanger.SetOpened(polaritySaveData.isUsed);
            }
        }
    }
}
