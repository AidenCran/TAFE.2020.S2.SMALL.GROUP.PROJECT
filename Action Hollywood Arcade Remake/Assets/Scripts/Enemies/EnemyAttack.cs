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
    /// </summary>
    public class EnemyAttack : MonoBehaviour
    {
        //Detects if the player collides with the enemy
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                onPlayerHit();
            }
        }

        public void onPlayerHit()
        {
            Debug.Log("Hit The Player");

            //Executes playerHit function
            PlayerLives.Instance.playerHit();
        }
    }
}
