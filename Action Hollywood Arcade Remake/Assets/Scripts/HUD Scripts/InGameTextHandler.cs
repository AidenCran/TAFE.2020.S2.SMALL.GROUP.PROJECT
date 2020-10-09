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

        //Directly references the PlayerData script
        public PlayerData pd;

        void Start()
        {
            //Loads the player's data
            SaveManager.Load();

            //Name only needs to be set once per wake.
            playerNameText.text = pd.playerName;
        }

        void Update()
        {
            //References the GameTime Script for the timer
            GameTime gameTime = HUDScripts.GetComponent<GameTime>();

            //Updates the time and score every frame
            timeRemainingText.text = gameTime.timeRemaining + "";
            playerScoreText.text = pd.playerScore + "";
        }
    }
}
