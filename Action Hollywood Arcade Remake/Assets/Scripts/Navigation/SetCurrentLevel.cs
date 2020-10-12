using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020
    /// 
    /// This script is responsible for recording the current level to the PlayerData file
    /// When a player loads into a level, this script will save the current scene as the current level. 
    /// This data is read when the player fails a level and needs to restart.
    /// This means the player will always get put to the last level they played.
    /// 
    /// The secondary function for this script is to determine the highest level the player has achieved.
    /// I use the scene's index to determine this. In the build settings the levels are setup to be the last scenes.
    /// Progressing from level 1 onwards, each higher index than the previous.
    /// 
    /// Noting the index allows us to determine what levels are unavailabe to the user. If the "HighestLevelAchieved" isn't high enough, the player cannot access it.
    /// 
    /// Also I could skip grabbing the scene name, and directly change the scene with the index. But that's just nitpicking.
    /// (Also I'd have to modfiy the GameNavigation script a bit too)
    /// </summary>
    public class SetCurrentLevel : MonoBehaviour
    {
        PlayerData pd;
        
        //States how many scenes are not "Level" scenes
        //This is used in the start function to check if the current level is higher or lower than to highest achieved
        int SceneIndexOffset;

        //Used to prevent the offset calculation from executing more than once
        bool CalculateOffset;

        public void Awake()
        {
            if (CalculateOffset == false)
            {
                //Checks what the index for the first level is
                FirstLevelIndexOffset();
                CalculateOffset = true;
            }
        }

        /// <summary>
        /// This calculates how many Scenes there are in the build and subtracts the current position of Level 1 from the total
        /// With this offset value, I can automatically account for adding more scenes without messing up the math
        /// This math is used to calculate the highest achieved Level
        /// </summary>
        public void FirstLevelIndexOffset()
        {
            int LevelOneSceneIndex;
            LevelOneSceneIndex = SceneManager.GetSceneByName("Level 1").buildIndex;

            int TotalScenes;
            TotalScenes = SceneManager.sceneCountInBuildSettings;

            SceneIndexOffset = TotalScenes - LevelOneSceneIndex;
            Debug.Log("Calcuated Offset = " + SceneIndexOffset);
        }

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

            //Automatically adjusts the current scene index to be #1
            //It accounts for any scenes above Level 1 without needing to be adjusted.
            CurrentSceneIndex = CurrentSceneIndex - SceneIndexOffset;

            //Compares the current scene's index to the highest set scene index
            if (CurrentSceneIndex > pd.HighestLevelAchieved)
            {
                //If the current scene's index is higher, then the highest is set to the current.
                pd.HighestLevelAchieved = CurrentSceneIndex;
                Debug.Log("New Highest Level = " + pd.HighestLevelAchieved);
            }

            //Saves the new data
            SaveManager.Save(pd);
        }
        
        /// <summary>
        /// Called on level completion -
        /// This function prevents the player increasing the current stage level, unless they complete the latest stage.
        /// E.g. They cannot finish level 1, 3 times to reach level 4.
        /// They must complete level 1, then 2, then 3, and finally 4.
        /// </summary>
        public void IncreaseHighestLevelOnWin()
        {
            //References the current scene's index #
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            Debug.Log("Current Index: " + CurrentSceneIndex);

            Debug.Log("Current Offset: " + SceneIndexOffset);

            //Automatically adjusts the current scene index to be #1
            //It accounts for any scenes above Level 1 without needing to be adjusted.
            CurrentSceneIndex = CurrentSceneIndex - SceneIndexOffset;

            Debug.Log("New Current Scene Index: " + CurrentSceneIndex);


            Debug.Log("IncreaseOnLevelWin Function Called");

            //Compares the current index to the highest current
            //If it is more than or equal to the highest, the player can continue
            //Else nothing happens
            if (CurrentSceneIndex >= pd.HighestLevelAchieved)
            {
                pd.HighestLevelAchieved += 1;

                //Saves the new data
                SaveManager.Save(pd);

                Debug.Log("Highest Level Increased By 1.");
                Debug.Log("New Highest Level = " + pd.HighestLevelAchieved);
            }
            else
            {
                Debug.Log("Highest Level Not Increased");
                Debug.Log("This Scene Index is " + CurrentSceneIndex);
                Debug.Log("Current Highest Level = " + pd.HighestLevelAchieved);
            }
        }
    }
}
