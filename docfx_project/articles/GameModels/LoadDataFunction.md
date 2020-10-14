Loading Player Data
===================

The Load function is also pretty straight forward

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
            pd = Save(pd);
        }

        return pd;
    }

We check if the full path exists, if it does, it reads the file. If it doesn't, it spits out an error and recalls the save function. Calling the save function will rebuild the path.

In the game, I've set it up that the save function is generally called enough that the player cannot continue without the path being built. 
