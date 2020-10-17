using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// 
    /// </summary>
    public class BoulderTrigger : MonoBehaviour
    {
        public GameObject BoulderRef;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //Calls the roll function
                BoulderRef.GetComponent<BoulderRoll>().BoulderRollForward();
            }
        }
    }
}
