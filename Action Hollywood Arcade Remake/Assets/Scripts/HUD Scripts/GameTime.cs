using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class GameTime : MonoBehaviour
    {
        public float timeRemaining = 5;

        public GameObject WinConditionReference;

        public bool hasWonRef;

        private void Start()
        {
            hasWonRef = WinConditionReference.GetComponent<GameOverCondition>().hasWon;
        }

        void Update()
        {
            if (timeRemaining > 0 && hasWonRef == false)
            {
                timeRemaining -= Time.deltaTime;
                //timeRemaining = Mathf.Round(timeRemaining * 100.0f) * 0.01f;
            }
        }
    }
}
