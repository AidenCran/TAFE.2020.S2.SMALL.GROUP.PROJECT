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
    /// Handles the win & lose functions (Scene Change + Level Increment Check) 
    /// </summary>
    public class WinLoseFunctions : MonoBehaviour
    {
        //Just a reference
        string SceneToLoad;
        
        public void LoseFunction()
        {
            //Loads the LoseScene
            SceneToLoad = "LoseScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }
        public void WinFunction()
        {
            //Calls a function to check if the level increment conditions have been met
            this.GetComponent<SetCurrentLevel>().IncreaseHighestLevelOnWin();

            //Loads the WinScene
            SceneToLoad = "WinScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }
    }
}
