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

        //These allow us to reference the in game text components.
        public Text timeRemainingText;
        public Text playerScoreText;
        public Text playerNameText;


        void Start()
        {
            //References the GameTime Script for the timer
            PlayerName playerName = HUDScripts.GetComponent<PlayerName>();

            //Name only needs to be set once per wake.
            playerNameText.text = playerName.Name;
        }

        void Update()
        {
            //References the GameTime Script for the timer
            GameTime gameTime = HUDScripts.GetComponent<GameTime>();

            //References the PlayerScore Script for the score
            PlayerScore playerScore = HUDScripts.GetComponent<PlayerScore>();

            //Updates the time and score every frame
            timeRemainingText.text = ("" + gameTime.timeRemaining);
            playerScoreText.text = ("Score: " + playerScore.Score);
        }
    }
}
