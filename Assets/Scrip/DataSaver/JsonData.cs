using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonData
{
    private static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save<DataList>(DataList data, string SaveFilename)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        Debug.Log(SavePath);
        string saveJson = JsonUtility.ToJson(data);

        string saveFilePath = SavePath + SaveFilename + ".json";
        File.WriteAllText(saveFilePath, saveJson);
    }

    public static string Load(string SaveFilename)
    {
        string saveFilePath = SavePath + SaveFilename + ".json";
        Debug.Log(SavePath);
        if (!File.Exists(saveFilePath))
        {
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        return saveFile;
    }
}
