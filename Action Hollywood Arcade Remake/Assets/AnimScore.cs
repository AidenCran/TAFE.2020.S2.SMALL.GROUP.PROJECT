//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using AidensWork;

//namespace Hoey.Demo.Scripts
//{
//    /// <summary>
//    /// This script demonstrates how to animate a score  
//    /// <para>https://answers.unity.com/questions/934659/c-adding-and-counting-up-scores-with-mathflerp.html </para>
//    /// 
//    /// <para>https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings</para>
//    /// <para>https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings</para>
//    /// 
//    /// </summary>
//    public class AnimScore : MonoBehaviour
//    {
//        [SerializeField] Text scoreText;
//        [SerializeField] float pointAnimDurationSec = 2f;

//        public float TotalScoreReference;

//        float pointAnimTimer = 0f;
//        // var for storing the actual current score.
//        // end point of the Lerp
//        float currentScore = 0;
//        // var for storing the score just before points were last added
//        // start point of the Lerp
//        float savedDisplayedScore = 0;
//        // a variable for the "animated" score you should show in the UI.
//        // We can't put the result of Lerp into
//        // the vars above because that would mess up the result of the next Lerp
//        float displayedScore = 0;
//        // ^^ Added the word "displayed" because neither 
//        // of these mark how many points th player really has.
//        // Afterall you animate the score just to make it pretty


//        void AddPoints(float points)
//        {
//            // A
//            // what if you get more points before last points finished animating ?
//            // start the animation again but from the score that was already being shown
//            // --> no sudden jump in score animation
//            savedDisplayedScore = displayedScore;
//            // B
//            // the player instantly has these points so nothng gets 
//            // messed up if e.g. level ends before score animation finishes
//            currentScore += points;
//            // Lerp gets a new end point
//            pointAnimTimer = 0f;
//        }

//        void Start()
//        {
//            TotalScoreReference = 

//            scoreText.text = displayedScore.ToString("0,000,000");
//        }

//        void Update()
//        {
//            if (displayedScore != currentScore)
//            {
//                pointAnimTimer += Time.deltaTime;
//                float percentageComplete = pointAnimTimer / pointAnimDurationSec;
//                // don't modify the start and end values here 
//                // prcComplete will grow linearly but if you change the start/end points
//                // it will add a cumulating error
//                displayedScore = Mathf.Lerp(savedDisplayedScore, currentScore, percentageComplete);
//                scoreText.text = displayedScore.ToString("N0"); //Number
//                                                                //scoreText.text = displayedScore.ToString("C0"); //Currency
//                                                                //scoreText.text = displayedScore.ToString("P0"); //Percent
//            }

            
//            //Just to test this works assign it to an Input (Enter)
//            if (Input.GetButtonDown("Submit"))
//            {
//                AddPoints(TotalScoreReference);
//            }
//        }
//    }
//}
