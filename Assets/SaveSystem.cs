using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public void SavePlayer (Playerstats player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }
}
