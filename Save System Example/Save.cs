using System.Net.Mime;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private const string SAVE_PATH = Application.persistentDataPath + "/save.devu";

    public static void Save (SaveController status)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(SAVE_PATH, FileMode.create);

        GameData data = new GameData(status);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static GameData Load ()
    {
        if (File.Exists(SAVE_PATH))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(SAVE_PATH, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        }
        else
            return null;
    }
}