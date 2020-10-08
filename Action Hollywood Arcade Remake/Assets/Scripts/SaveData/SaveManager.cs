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

    public static void Save(PlayerData pd)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(pd);
        File.WriteAllText(dir + fileName, json);
    }

    public static PlayerData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        PlayerData pd = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            pd = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save File Does Not Exist");
        }

        //Debug.Log(fullPath);

        return pd;
    }
}
