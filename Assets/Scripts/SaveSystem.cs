using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public static class SaveSystem
{
    /// <summary>
    /// Binary file storage path, independent from the system running on
    /// </summary>
    private static string path = Application.persistentDataPath + "/player.fun";

    /// <summary>
    /// List of existing players data.  
    /// </summary>
    //private static List<PlayerData> playersData = new List<PlayerData>();
    private static Collection<PlayerData> playersData = new Collection<PlayerData>();

    /// <summary>
    /// Stores player object into binary file.
    /// </summary>
    public static void SavePlayer(GameManager gameManager)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);

        playersData.Add(data);

        formatter.Serialize(fileStream, playersData);
        fileStream.Close();
    }

    /// <summary>
    /// Read binary file and return PlayerData object.
    /// </summary>
    public static Collection<PlayerData> LoadPlayer()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            if (fileStream.Length > 0)
            {
                //playersData = formatter.Deserialize(fileStream) as List<PlayerData>;
                playersData = formatter.Deserialize(fileStream) as Collection<PlayerData>;
            }
            fileStream.Close();

            return playersData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
