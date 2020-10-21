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
        }

        void Update()
        {
            GetCurrentData();
        }

        void GetCurrentData()
        {
            //References the GameTime Script for the timer
            GameTime gameTime = HUDScripts.GetComponent<GameTime>();

            //Updates the time
            timeRemainingText.text = gameTime.timeRemaining.ToString("N0");
        }

        public void SetCurrentLives()
        {
            PlayerLivesRef = PlayerLives.Instance.playerLives;

            LifeSprites[PlayerLivesRef].gameObject.SetActive(false);
        }
    }
}
