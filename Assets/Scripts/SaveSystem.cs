using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save( GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        bf.Serialize(fs, gameData);
        fs.Close();
    }


    public static GameData Load( )
    {
        if (!File.Exists(GetPath()))
        {
            GameData emptyData = new GameData();
            Save( emptyData );
            return emptyData;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(),FileMode.Open);
        GameData data = bf.Deserialize(fs) as GameData;
        fs.Close();
        return data;

    }

    private static string GetPath()
    {
		return Application.persistentDataPath + "/data.qnd";

	}
}
