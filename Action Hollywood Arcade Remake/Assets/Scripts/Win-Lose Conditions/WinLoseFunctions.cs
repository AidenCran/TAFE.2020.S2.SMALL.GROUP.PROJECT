using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020
    /// 
    /// Handles the win & lose functions (Scene Change) 
    /// </summary>
    public class WinLoseFunctions : MonoBehaviour
    {
        string SceneToLoad;
        PlayerData pd;

        public void LoseFunction()
        {
            SceneToLoad = "LoseScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }
        public void WinFunction()
        {
            //Loads data
            pd = SaveManager.Load();
            //Increases the highest level by 1
            pd.HighestLevelAchieved += 1;

            SaveManager.Save(pd);

            SceneToLoad = "WinScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }
    }
}
