using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 10/10/2020
    /// 
    /// This script simply iterates through all of the Level buttons in the stage selection screen
    /// If the button ID (Level 1 = 1, Level 2 = 2, etc.) is more than the Highest Level Achieved, and is not Level 1, deactivate it
    /// This prevents players from opening levels higher than they have access to.
    /// </summary>
    public class StageSelection : MonoBehaviour
    {
        public GameObject[] StageSelectionButtons;
        PlayerData pd;

        public void Start()
        {
            pd = SaveManager.Load();
            //Debug.Log(StageSelectionButtons[0].GetComponentInChildren<LevelID>().thisLevelID);
            
            currentLevelCheck();
            Debug.Log("Stage Selection Loaded");

        }

        public void currentLevelCheck()
        {
            //Automatically gets the updated Build index
            //PROBLEM: Returns -1 instead of build index
            //Temp Fix: Just keeping the current index updated in the player data script
            //LevelOneSceneIndex = SceneManager.GetSceneByName("Level 1").buildIndex;

            //Runs through all levels in the array
            for (int i = 0; i < StageSelectionButtons.Length; i++)
            {
                //References the correct stage ID
                //int thisLevelID = StageSelectionButtons[i].GetComponentInChildren<LevelID>().thisLevelID;

                
                int thisLevelID = i + pd.LevelOneSceneIndex;
                //Debug.Log("Level ID = " + thisLevelID);

                StageSelectionButtons[i].GetComponentInChildren<LevelID>().thisLevelID = thisLevelID;
                //Debug.Log("Button ID = " + StageSelectionButtons[i].GetComponentInChildren<LevelID>().thisLevelID);

                if (thisLevelID > pd.HighestLevelAchieved && thisLevelID != pd.LevelOneSceneIndex)
                {
                    StageSelectionButtons[i].SetActive(false);
                }
            }
        }
    }
}
