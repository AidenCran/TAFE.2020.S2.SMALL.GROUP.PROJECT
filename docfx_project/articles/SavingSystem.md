Game Saving System
==================

### Save Manager

The save manager handles both the saving and loading functions. These functions read and write to a file created within' a persistant data path. This means that no matter what system the game is played on, the path will always exist.

In the persistant file path, the folder "SaveData" will be created, within' it the playerData file will be stored.

    public static string directory = "/SaveData/";
    public static string fileName = "playerData.txt";

## The Save Function

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

## The Load Function

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


### PlayerData Script

The Player Data script holds all the variables that will be saved into the text file.

If you want to modify one of these variables, you simply reference it with the filename. This file is not appart of monobehaviour, so you cannot directly reference it by pulling it into the scene.

## PlayerData code

    [System.Serializable]

    public class PlayerData
    {
        //Place the player data here. 
        //This data is accessable anywhere through directly referencing the PlayerData script.
        public string playerName;
        public int playerScore;

        //References which level the player left off on.
        public string CurrentLevel;

        //Keeps track of the highest level the player has gotten to.
        public int HighestLevelAchieved;
    }

That's it. This file's only purpose is for holding the data between storing and loading it.

To do this however, we require the use of '' [System.Serializable] '' 

### Saving the current level

The "SetCurrentLevel" script does less of saving the contents of a level, and more of saving which level the player is upto. This will be useful so when the player closes the game and reopens it, they will keep their level progress, well a fraction of it. They will need to restart the level, but their total progress will be saved.

## Level Save Code

    public class SetCurrentLevel : MonoBehaviour
    {
        PlayerData pd;
        public void Start()
        {
            //Loads data
            pd = SaveManager.Load();

            //References the current scene name
            string currentSceneName = SceneManager.GetActiveScene().name;

            //Sets the active scene to the current level
            pd.CurrentLevel = currentSceneName;
            Debug.Log("Current Scene = " + currentSceneName);

            //References the current scene's index #
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            //Compares the current scene's index to the highest set scene index
            if (CurrentSceneIndex > pd.HighestLevelAchieved)
            {
                //If the current scene's index is higher, then the highest is set to the current.
                CurrentSceneIndex = pd.HighestLevelAchieved;
                Debug.Log("New Highest Level = " + pd.HighestLevelAchieved);
            }

            //Saves the new data
            SaveManager.Save(pd);
        }
    }

The entire script is centered on running once, at start time.

To start, the file loads the latest data from the PlayerData file.

We then grab the current scene name and store it under a variable. 
This variable is then saved to a variable within' the PlayerData script.
We also grab the Index for the current scene and compare it to the highest Index the player has achived.
If the current Index is higher than the saved Highest, the new highest is recorded and all the altered data is re-saved in the PlayerData.txt file

The reason we grab the current index to decide what the highest level the player has achived.
In the stage selection scene, stages are locked until the previous stage has been completed. By setting the highest scene, the player can unlock higher levels later on.
In the build settings, the playable levels are structured next to each other in assending order. This makes it easy to figure out which stage the player is upto...

