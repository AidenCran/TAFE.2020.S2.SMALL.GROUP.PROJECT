using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// 
    /// 
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
            //Runs through all levels in the array
            for (int i = 0; i < StageSelectionButtons.Length; i++)
            {
                //References the correct stage ID
                int thisLevelID = StageSelectionButtons[i].GetComponentInChildren<LevelID>().thisLevelID;


                if (thisLevelID > pd.HighestLevelAchieved && thisLevelID != 1)
                {
                    StageSelectionButtons[i].SetActive(false);
                }
            }
        }
    }
}
