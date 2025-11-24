using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using System.Runtime.Serialization;
public class saveSystem : MonoBehaviour
{
    public static void SavePlayer(movement player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player); 

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static playerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           playerData data = formatter.Deserialize(stream) as playerData;
           stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in"+path);
            return null;
        }
    }

}
