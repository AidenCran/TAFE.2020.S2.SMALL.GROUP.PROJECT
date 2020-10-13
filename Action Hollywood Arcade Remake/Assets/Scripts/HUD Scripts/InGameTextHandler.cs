using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AidensWork;

namespace AidensWork
{
    public class InGameTextHandler : MonoBehaviour
    {
        //References the TimerScript
        public GameObject HUDScripts;

        //References the Score Calc script
        public GameObject ScoreCalcReference;

        //
        public GameObject ScoreScreenRef;

        //Directly references the PlayerData script
        public PlayerData pd;

        //These allow us to reference the in game text components.
        //These connect to the text In Game
        public Text timeRemainingText;
        public Text playerScoreText;
        public Text playerNameText;


        //The Below Values are references for the Score Screen

        //Creates reference for each value
        public int AmountOfExtraTime;
        public int BrickAmountPickedUp;
        public int SecretAmountFound;
        public int TotalScore;

        //These connect to the text within' the Score Menu
        public Text AmountOfExtraTimeText;
        public Text BrickAmountPickedUpText;
        public Text SecretAmountFoundText;

        public Text TotalScoreText;
        //public Text TimeBonus;
        //public Text BrickBonus;
        //public Text SecretBonus;

        public bool EndCalculatingScore;

        void Start()
        {
            //Loads the player's data
            pd = SaveManager.Load();

            //Name only needs to be set once per wake.
            playerNameText.text = pd.playerName;

            //Sets Score Screen off by default
            ScoreScreenRef.SetActive(false);

            ///Below are values for the Score Screen///

            //References Amount of each value
            AmountOfExtraTime = this.gameObject.GetComponent<ScoreCalc>().AmountOfExtraTime;
            BrickAmountPickedUp = this.gameObject.GetComponent<ScoreCalc>().BrickAmountPickedUp;
            SecretAmountFound = this.gameObject.GetComponent<ScoreCalc>().SecretAmountFound;

            //References the Total
            //int TotalScore = this.gameObject.GetComponent<ScoreCalc>().TotalScoreBonus;
            //int TimeBonus = this.gameObject.GetComponent<ScoreCalc>().TimeScoreBonus;
            //int BrickBonus = this.gameObject.GetComponent<ScoreCalc>().BrickScoreBonus;
            //int SecretBonus = this.gameObject.GetComponent<ScoreCalc>().SecretScoreBonus;
        }

        void Update()
        {
            //References the GameTime Script for the timer
            GameTime gameTime = HUDScripts.GetComponent<GameTime>();

            //Updates the time and score every frame
            timeRemainingText.text = gameTime.timeRemaining.ToString(); ;
            playerScoreText.text = $"SCORE: {TotalScore + pd.playerScore}" ;

            ///Below are values for the Score Screen///

            AmountOfExtraTimeText.text = AmountOfExtraTime.ToString();
            BrickAmountPickedUpText.text = BrickAmountPickedUp.ToString();
            SecretAmountFoundText.text = SecretAmountFound.ToString();
        }

        public void ScoreScreenAni()
        {

            ScoreScreenRef.SetActive(true);

            //int _AmountOfExtraTime = AmountOfExtraTime;

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
                    Debug.Log("Extra Time Left: " + AmountOfExtraTime);
                }

                //Second reduces brick bonus to 0
                for (int i = 0; i < BrickAmountPickedUp; i++)
                {
                    BrickAmountPickedUp--;
                    TotalScore += 200;
                    Debug.Log("Extra Bricks Left: " + BrickAmountPickedUp);
                }

                //Third and last reduces secret bonus to 0
                for (int i = 0; i < SecretAmountFound; i++)
                {
                    SecretAmountFound--;
                    TotalScore += 300;
                    Debug.Log("Extra Secrets Left: " + SecretAmountFound);
                }

                if (AmountOfExtraTime == 0 && BrickAmountPickedUp == 0 && SecretAmountFound == 0)
                {
                    Debug.Log("End of calculation");
                    EndCalculatingScore = true;
                }
            }
        }
    }
}
