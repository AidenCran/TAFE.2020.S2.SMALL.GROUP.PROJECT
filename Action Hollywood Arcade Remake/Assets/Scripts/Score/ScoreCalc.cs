using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// Called on win.
    /// Calculates all the score perameters.
    /// </summary>
    public class ScoreCalc : MonoBehaviour
    {
        public int TotalScoreBonus;

        //Total Added Score from Bonus time
        public int TimeScoreBonus;
        //Amount of extra time the player has
        public int AmountOfExtraTime = 50;
        //How much bonus is added per 
        private int TimeBonusAmount = 100;

        //Total Added Score from Brick Pickups
        public int BrickScoreBonus;
        //Amount the player picked up
        public int BrickAmountPickedUp = 40;
        //How much bonus is added per 
        private int BrickBonusAmount = 200;

        //Total Added score from secrets
        public int SecretScoreBonus;
        //Amount of secrets found
        public int SecretAmountFound = 30;
        //How much bonus is added per 
        private int SecretBonusAmount = 300;

        private void Start()
        {
            
        }

        public void ScoreCalculation()
        {
            //References score on win
            float CurrentTimeLeft = this.gameObject.GetComponent<GameTime>().timeRemaining;
            //Rounds current time to nearest Int
            int CurrentRoundedTime = Mathf.RoundToInt(CurrentTimeLeft);

            AmountOfExtraTime = CurrentRoundedTime;

            //Calcs Total Score
            //For Time
            TimeScoreBonus = CurrentRoundedTime * TimeBonusAmount;
            //For Bricks
            BrickScoreBonus = BrickAmountPickedUp * BrickBonusAmount;
            //For Secrets
            SecretBonusAmount = SecretAmountFound * SecretBonusAmount;

            //Total
            TotalScoreBonus = TimeScoreBonus + BrickScoreBonus + SecretBonusAmount;

            this.GetComponent<InGameTextHandler>().ScoreScreenAni();
        }
    }
}
