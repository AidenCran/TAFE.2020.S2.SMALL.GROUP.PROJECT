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

        public bool hasWon;

        bool AUTOWIN = true;

        public void Update()
        {
            if (TimerReference.GetComponent<GameTime>().timeRemaining == 0)
            {
                //Call Game Over Function
                this.GetComponent<WinLoseFunctions>().LoseFunction();
            }

            if (this.GetComponent<TileTracker>().TilesRemaining == 0 || Input.GetKeyDown(KeyCode.Space))
            {
                //Call Game Win Function
                hasWon = true;
                //Calculates the score
                TimerReference.GetComponent<ScoreCalc>().ScoreCalculation();
                //this.GetComponent<WinLoseFunctions>().WinFunction();
            }
        }
    }
}
