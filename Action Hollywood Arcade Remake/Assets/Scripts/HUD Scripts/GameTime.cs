using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class GameTime : MonoBehaviour
    {
        public float timeRemaining = 60;

        void Update()
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //timeRemaining = Mathf.Round(timeRemaining * 100.0f) * 0.01f;
            }
        }
    }
}
