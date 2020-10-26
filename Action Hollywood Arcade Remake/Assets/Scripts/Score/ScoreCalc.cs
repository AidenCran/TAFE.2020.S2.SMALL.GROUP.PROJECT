using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AidensWork;
using Hoey.Demo.Scripts;
using Hoey.Examples;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// Called on win.
    /// Calculates all the score parameters.
    /// </summary>
    public class ScoreCalc : MonoBehaviour
    {
        #region ---[ singleton code base ]---

        // Singleton Reference
        private static ScoreCalc _instance;
        public static ScoreCalc Instance { get { return _instance; } }

        // Setup Variables
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        PlayerData pd;

        public GameObject PlayerCharacterRef;

        public GameObject ScoreScreenRef;

        //
        public int TotalScore;

        //Total Score the player has accumulated
        public int TotalScoreBonus;

        //Total Added Score from Bonus time
        public int TimeScoreBonus;
        //Amount of extra time the player has
        public int AmountOfExtraTime;
        //How much bonus is added per 
        private int TimeBonusPer = 100;

        //Total Added Score from Brick Pickups
        public int BrickScoreBonus;
        //Amount the player picked up
        public int BrickAmountPickedUp;
        //How much bonus is added per 
        private int BrickBonusPer = 200;

        //Total Added score from secrets
        public int SecretScoreBonus;
        //Amount of secrets found
        public int SecretAmountFound;
        //How much bonus is added per 
        private int SecretBonusPer = 300;

        public void IncreaseScore(int AddedScore)
        {
            //Sends the score increase to the Score Animator
            this.GetComponent<AnimScore>().AddPoints(AddedScore);

            //Increases Total Score
            TotalScore += AddedScore;
        }

        /// <summary>
        /// Called at end of round.
        /// Calculates the players score.
        /// </summary>
        public void ScoreCalculation()
        {
            pd = SaveManager.Load();

            //References score on win
            float CurrentTimeLeft = this.gameObject.GetComponent<GameTime>().timeRemaining;
            //Rounds current time to nearest Int
            int CurrentRoundedTime = Mathf.RoundToInt(CurrentTimeLeft);

            AmountOfExtraTime = CurrentRoundedTime;

            Debug.Log("Time Remaining: " + CurrentRoundedTime);

            //Calcs Total Score
            //For Time
            TimeScoreBonus = AmountOfExtraTime * TimeBonusPer;
            //For Bricks
            BrickScoreBonus = BrickAmountPickedUp * BrickBonusPer;
            //For Secrets
            SecretScoreBonus = SecretAmountFound * SecretBonusPer;

            //Total
            TotalScoreBonus = TimeScoreBonus + BrickScoreBonus + SecretScoreBonus;

            IncreaseScore(TotalScoreBonus);

            //Prevents the player from moving
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = false;

            //Activates the score screen
            ScoreScreenRef.SetActive(true);






            ///DISABLED FOR NOW, WILL CHANGE LATER///

            ////References the current scene's index #
            //int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            //if (CurrentSceneIndex >= pd.HighestLevelAchieved)
            //{
            //    //Adds the Total score bonus to the PlayerData file
            //    pd.playerScore += TotalScoreBonus;
            //}

            ////Saves PlayerScore Data
            //SaveManager.Save(pd);
        }
    }
}
