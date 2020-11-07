using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 29/10/2020
    /// Last Edited:
    /// 
    /// Handles the health and worth of each enemy. When the enemy is hit it checks how much health it has, if its more than 0 it reduces it by 1.
    /// When the enemy reaches 0 health, score is increased and the object is deleted.
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        // Default Should Be 2 or 3
        public int currentEnemyHealth = 1;

        public int EnemyScore = 100;

        // Ignore This
        public GameObject EnemyRef;

        Renderer EnemyRenderer;

        private void Start()
        {
            EnemyRenderer = EnemyRef.GetComponent<Renderer>();
        }

        public void OnDamageTaken()
        {
            // If enemy health is 0
            if (currentEnemyHealth <= 0)
            {
                // Calls function to visually display the increased score and add score to total.
                ScoreCalc.Instance.IncreaseScore(EnemyScore);

                // Destroys enemy gameobject
                Destroy(gameObject);
            }
            else
            {
                EnemyRenderer.material.SetColor("_Color", Color.red);

                currentEnemyHealth--;
            }
        }
    }
}
