Saving Player Data
==================

The save function itself is very straight forward

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

It checks if the directory exists, if it doesn't it creates it. Then it writes the data from the PlayerData file which was passed in the method variables. The file is formatted with Json settings, which means it's easy to read and write to it. However this also means it's completely unprotected from the player.

For the purpose of this assignment this is good enough, however for practical use this file should be Binary serialized at least.
