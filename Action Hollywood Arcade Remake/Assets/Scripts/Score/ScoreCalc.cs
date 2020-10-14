using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        PlayerData pd;

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
            pd = SaveManager.Load();
        }

        public void ScoreCalculation()
        {
            //References score on win
            float CurrentTimeLeft = 5;//this.gameObject.GetComponent<GameTime>().timeRemaining;
            //Rounds current time to nearest Int
            int CurrentRoundedTime = Mathf.RoundToInt(CurrentTimeLeft);

            AmountOfExtraTime = CurrentRoundedTime;

            //Calcs Total Score
            //For Time
            TimeScoreBonus = 50 * TimeBonusAmount;
            //For Bricks
            BrickScoreBonus = BrickAmountPickedUp * BrickBonusAmount;
            //For Secrets
            SecretBonusAmount = SecretAmountFound * SecretBonusAmount;

            //Total
            TotalScoreBonus = TimeScoreBonus + BrickScoreBonus + SecretBonusAmount;

            //References the current scene's index #
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (CurrentSceneIndex >= pd.HighestLevelAchieved)
            {
                //Adds the Total score bonus to the PlayerData file
                pd.playerScore += TotalScoreBonus;
            }

            //Saves PlayerScore Data
            SaveManager.Save(pd);

            this.GetComponent<InGameTextHandler>().ScoreScreenAni();
        }
    }
}
