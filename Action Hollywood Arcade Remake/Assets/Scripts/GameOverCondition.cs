using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020
    /// Last Edited: 13/10/2020
    /// 
    /// Determines if the player has met the win conditions or the lose conditions
    /// Triggers correct function on win / loss
    /// </summary>
    public class GameOverCondition : MonoBehaviour
    {
        public GameObject TimerReference;

        //Just a reference
        string SceneToLoad;

        public bool GameOver;

        public void Update()
        {
            if (GameOver == false)
            {
                if (TimerReference.GetComponent<GameTime>().timeRemaining <= 0)
                {
                    //Stops the loop
                    GameOver = true;
                    //Call Game Lose Function
                    LoseFunction();
                }

                if (this.GetComponent<TileTracker>().TilesRemaining == 0)
                {
                    //Stops the loop
                    GameOver = true;
                    //Cals Game Win Function
                    WinFunction();
                }
            }
        }

        public void LoseFunction()
        {
            //Loads the LoseScene
            SceneToLoad = "LoseScene";
            this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }

        public void WinFunction()
        {
            //Stops the loop
            //This is here again just for Debug Purposes
            GameOver = true;

            //Calls a function to check if the level increment conditions have been met
            this.GetComponent<SetCurrentLevel>().IncreaseHighestLevelOnWin();

            //Calculates the score
            TimerReference.GetComponent<ScoreCalc>().ScoreCalculation();

            //Loads the WinScene
            //SceneToLoad = "WinScene";
            //this.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
        }
    }
}
