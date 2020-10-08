using UnityEngine;
using System.IO;

/// <summary>
/// Author*: Aiden Cran 
/// Date: 8/10/2020
/// 
/// This script handles saving Data to a persistant directory
/// This saving method isn't protected against the user, so only basic details are stored in it.
/// 
/// I followed Comp-3's Video on Saving Data
/// https://www.youtube.com/watch?v=aV2OA4f5ru8
/// </summary>
public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "playerData.txt";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save File Does Not Exist");
        }

        //Debug.Log(fullPath);

        return so;
    }
}
