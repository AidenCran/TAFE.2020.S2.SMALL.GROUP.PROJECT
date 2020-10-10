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

            //We reduce it by 3 to account for the non-level scenes
            //Ideally this shouldn't be reduced by 3, but by a calculation done with the current scenes etc.
            //However for now 3 is fine.
            CurrentSceneIndex -= 3;

            Debug.Log("This Scene Index is " + CurrentSceneIndex);
            Debug.Log("Current Highest Level = " + pd.HighestLevelAchieved);

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
    }
}
