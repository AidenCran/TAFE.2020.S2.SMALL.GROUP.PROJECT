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

