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
    /// </summary>
    public class SetCurrentLevel : MonoBehaviour
    {
        PlayerData pd;
        public void Start()
        {
            //Loads data
            SaveManager.Load();

            //References the current scene name
            string currentSceneName = SceneManager.GetActiveScene().name;
            //Sets the active scene to the current level
            pd.CurrentLevel = currentSceneName;

            //References the current scene's index #
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            //Compares the current scene's index to the highest set scene index
            if (CurrentSceneIndex > pd.HighestLevelAchieved)
            {
                //If the current scene's index is higher, then the highest is set to the current.
                CurrentSceneIndex = pd.HighestLevelAchieved;
            }
        }
    }
}
