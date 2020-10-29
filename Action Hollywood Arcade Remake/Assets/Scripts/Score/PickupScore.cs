using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;
using Hoey.Demo.Scripts;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 20/10/2020
    /// Last Edited:
    /// 
    /// This script Handles picking up score objects e.g. Coins, Gems, etc. 
    /// </summary>
    public class PickupScore : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "ScoreObject")
            {
                int AmountToIncreaseScoreBy;

                //How much is this object worth?
                AmountToIncreaseScoreBy = other.GetComponentInParent<ValueOfObject>().ValueOfThisObject;

                //Calls function to visually display the increased score and add score to total.
                ScoreCalc.Instance.IncreaseScore(AmountToIncreaseScoreBy);

                //Removes object from scene
                Destroy(other.gameObject);
            }

            if (other.tag == "TimeObject")
            {
                int AmountToIncreaseScoreBy;

                //How much is this object worth?
                AmountToIncreaseScoreBy = other.GetComponentInParent<ValueOfObject>().ValueOfThisObject;

                //Calls function to visually display the increased score and add score to total.
                ScoreCalc.Instance.IncreaseTime(AmountToIncreaseScoreBy);

                //Removes object from scene
                Destroy(other.gameObject);
            }
        }
    }
}
