using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static readonly string saveFileLocation = Application.dataPath + "/SaveFile.txt";

    public static void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        File.WriteAllText(saveFileLocation, json);
    }
    public static void LoadData<T>(ref T data)
    {
        if (File.Exists(saveFileLocation))
        {
            string saveString = File.ReadAllText(saveFileLocation);

            data = JsonUtility.FromJson<T>(saveString);
        }
    }
}
