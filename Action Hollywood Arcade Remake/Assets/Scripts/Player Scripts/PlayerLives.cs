using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;
using Hoey.Examples;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// 
    /// </summary>
    public class PlayerLives : MonoBehaviour
    {
        #region ---[ singleton code base ]---

        // Singleton Reference
        private static PlayerLives _instance;
        public static PlayerLives Instance { get { return _instance; } }

        // Setup Variables
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        public GameObject HUDScriptsRef;
        public GameObject PlayerCharacterRef;

        public bool isPlayerDead;
        
        [Tooltip("Determines how many lives the player has, duh")]
        public int playerLives = 3;

        public float AnimationTime = 3f;
        public float InvinciblityFrames = 5f;

        public Material playerMaterial;

        private void Start()
        {
            playerMaterial = PlayerCharacterRef.GetComponent<Material>();

            //playerMaterial.SetColor.
        }

        private void Update()
        {
            CheckPlayerDeath();
        }

        /// <summary>
        /// Called when the player has been hit
        /// </summary>
        public void playerHit()
        {
            //Reduces lives by 1
            playerLives--;

            //Calls a function to update the visual elements (Lives Icons)
            HUDScriptsRef.GetComponent<InGameTextHandler>().SetCurrentLives();

            //Handles the death sequence
            StartCoroutine(playerDeathSequence());
        }

        /// <summary>
        /// Coroutine which plays the death animation.
        /// In this time the player is prevented from moving.
        /// </summary>
        /// <returns></returns>
        IEnumerator playerDeathSequence()
        {
            //Play death animation

            //Freeze player controls
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = false;

            //Changes the player's tag so he cannot be hit
            PlayerCharacterRef.tag = "Invincible";

            Debug.Log($"Death Sequence Started.");
            Debug.Log($"Player Is Invincible");

            yield return new WaitForSeconds(AnimationTime);

            Debug.Log($"Animation Over");

            //Unfreezes player controls
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = true;

            StartCoroutine(IFrames());
        }

        /// <summary>
        /// Coroutine giving the player invincibility frames
        /// </summary>
        /// <returns></returns>
        IEnumerator IFrames()
        {
            //The player is still invincible
            yield return new WaitForSeconds(InvinciblityFrames);

            Debug.Log($"Invincibility Over");

            //Resets the player's tag, allowing him to get hit again
            PlayerCharacterRef.tag = "Player";
        }

        void CheckPlayerDeath()
        {
            if (playerLives <= 0)
            {
                isPlayerDead = true;
            }
        }
    }
}
