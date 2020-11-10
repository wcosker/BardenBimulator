using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveData (WaterBucket bucket, PlayerControls player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.swag";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(bucket, player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadBucket ()
    {
        string path = Application.persistentDataPath + "/data.swag";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
