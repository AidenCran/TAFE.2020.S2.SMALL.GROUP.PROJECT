using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AidensWork;
using Hoey.Examples;

namespace AidensWork
{
    public class InGameTextHandler : MonoBehaviour
    {
        //References the TimerScript
        public GameObject HUDScripts;

        //References the Score Calc script
        public GameObject ScoreCalcReference;

        //References the score screen 
        public GameObject ScoreScreenRef;

        //References the player character
        public GameObject PlayerCharacterRef;

        //Directly references the PlayerData script
        public PlayerData pd;

        //These allow us to reference the in game text components.
        //These connect to the text In Game
        public Text timeRemainingText;
        public Text playerScoreText;
        public Text playerNameText;

        //These connect to the text within' the Score Menu
        public Text AmountOfExtraTimeText;
        public Text BrickAmountPickedUpText;
        public Text SecretAmountFoundText;

        public Text TotalScoreText;
        //public Text TimeBonus;
        //public Text BrickBonus;
        //public Text SecretBonus;

        //The Below Values are references for the Score Screen

        //Creates reference for each value
        public int AmountOfExtraTime;
        public int BrickAmountPickedUp;
        public int SecretAmountFound;
        public int TotalScore;

        //Determines when the calculation is finished
        public bool EndCalculatingScore;

        //These work in conjunction with the player lives scripts
        //public GameObject LifeSpriteHolder;
        public GameObject[] LifeSprites;

        public int PlayerLivesRef = 3;

        void Start()
        {
            //Loads the player's data
            pd = SaveManager.Load();

            //Initializes current score as saved score.
            //TotalScore = pd.playerScore;

            //Name only needs to be set once per wake.
            playerNameText.text = pd.playerName;

            //Sets Score Screen off by default
            ScoreScreenRef.SetActive(false);

            ///Below are values for the Score Screen///

            //References Amount of each value
            AmountOfExtraTime = this.gameObject.GetComponent<ScoreCalc>().AmountOfExtraTime;
            BrickAmountPickedUp = this.gameObject.GetComponent<ScoreCalc>().BrickAmountPickedUp;
            SecretAmountFound = this.gameObject.GetComponent<ScoreCalc>().SecretAmountFound;

            ///PRETTY SURE DO NOT NEED. WILL DELETE SOON///
            ///References the Total
            ///int TotalScore = this.gameObject.GetComponent<ScoreCalc>().TotalScoreBonus;
            ///int TimeBonus = this.gameObject.GetComponent<ScoreCalc>().TimeScoreBonus;
            ///int BrickBonus = this.gameObject.GetComponent<ScoreCalc>().BrickScoreBonus;
            ///int SecretBonus = this.gameObject.GetComponent<ScoreCalc>().SecretScoreBonus;
            ///PRETTY SURE DO NOT NEED. WILL DELETE SOON///
        }

        void Update()
        {
            GetCurrentData();
        }

        void GetCurrentData()
        {
            //References the GameTime Script for the timer
            GameTime gameTime = HUDScripts.GetComponent<GameTime>();

            TotalScore = ScoreCalc.Instance.TotalScoreBonus;

            //Updates the time
            timeRemainingText.text = gameTime.timeRemaining.ToString("N0");

            //playerScoreText.text = "SCORE: " + TotalScore.ToString("N0");

            ///Below are values for the Score Screen///
            AmountOfExtraTimeText.text = AmountOfExtraTime.ToString("00");
            BrickAmountPickedUpText.text = BrickAmountPickedUp.ToString("00");
            SecretAmountFoundText.text = SecretAmountFound.ToString("00");

            ///Below are values for the player lives
            //-----
        }

        public void SetCurrentLives()
        {
            PlayerLivesRef = PlayerLives.Instance.playerLives;

            LifeSprites[PlayerLivesRef].gameObject.SetActive(false);
        }

        public void ScoreScreenAni()
        {
            //Prevents the player from moving
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = false;
            //Activates the score screen
            ScoreScreenRef.SetActive(true);

            while (EndCalculatingScore == false)
            {
                //From top to bottom visually
                //First reduces time bonus to 0
                for (int i = 0; i < AmountOfExtraTime; i++)
                {
                    //Change -- to something like 
                    //-= Mathf.RoundToInt(Time.deltaTime);
                    //AmountOfExtraTime -= Mathf.RoundToInt(1 * Time.deltaTime);

                    //I Want to change this to reduce # by seconds
                    AmountOfExtraTime--;
                    TotalScore += 100;
                }





                //Second reduces brick bonus to 0
                for (int i = 0; i < BrickAmountPickedUp; i++)
                {
                    BrickAmountPickedUp--;
                    TotalScore += 200;
                }

                //Third and last reduces secret bonus to 0
                for (int i = 0; i < SecretAmountFound; i++)
                {
                    SecretAmountFound--;
                    TotalScore += 300;
                }

                if (AmountOfExtraTime == 0 && BrickAmountPickedUp == 0 && SecretAmountFound == 0)
                {
                    //Debug.Log("End of calculation");

                    //Debug.Log($"PlayerData Score: {pd.playerScore}");

                    EndCalculatingScore = true;
                }
            }
        }
    }
}
