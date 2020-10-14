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
    /// Determines if the player has met the win conditions or the lose conditions
    /// </summary>
    public class GameOverCondition : MonoBehaviour
    {
        public GameObject TimerReference;

        //Just a reference
        string SceneToLoad;

        public bool hasWon;
        public bool hasLost;

        public void Update()
        {
            if (hasWon == false && hasLost == false)
            {
                if (TimerReference.GetComponent<GameTime>().timeRemaining == 0)
                {
                    //Stops the loop
                    hasLost = true;
                    //Call Game Over Function
                    LoseFunction();
                }

                if (this.GetComponent<TileTracker>().TilesRemaining == 0)// || Input.GetKeyDown(KeyCode.Space))
                {
                    //Stops the loop
                    hasWon = true;
                    //Calculates the score
                    TimerReference.GetComponent<ScoreCalc>().ScoreCalculation();
                    //WinFunction();
                }
            }
        }

        public void LoseFunction()
        {
            //Loads the LoseScene
            SceneToLoad = "LoseScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }

        //public void WinFunction()
        //{
        //    //Calls a function to check if the level increment conditions have been met
        //    this.GetComponent<SetCurrentLevel>().IncreaseHighestLevelOnWin();

        //    //Loads the WinScene
        //    SceneToLoad = "WinScene";
        //    this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        //}
    }
}
