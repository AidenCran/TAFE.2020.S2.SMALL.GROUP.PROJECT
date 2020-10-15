using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class GameTime : MonoBehaviour
    {
        public float timeRemaining = 90;

        public GameObject WinConditionReference;

        public bool hasWonRef;

        void Update()
        {
            hasWonRef = WinConditionReference.GetComponent<GameOverCondition>().GameOver;

            if (timeRemaining > 0 && hasWonRef == false)
            {
                timeRemaining -= Time.deltaTime;
                //timeRemaining = Mathf.Round(timeRemaining * 100.0f) * 0.01f;
            }
        }
    }
}
