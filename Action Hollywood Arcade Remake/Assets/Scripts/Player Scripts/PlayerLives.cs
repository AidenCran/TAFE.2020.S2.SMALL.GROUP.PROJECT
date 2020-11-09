using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;
using Hoey.Examples;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 16/10/2020
    /// Last Edited: 17/10/2020
    /// 
    /// Handles Player Lives, IFrames, Death Checking and calling the HUD scripts to change the Visual aspects (Life Bar)
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

        //Script References
        public GameObject HUDScriptsRef;
        public GameObject PlayerCharacterRef;

        public bool isPlayerDead;
        
        [Tooltip("Determines how many lives the player has, duh")]
        public int playerLives = 3;

        //Variables related to IEnumerators
        private float AnimationTime = 3f;
        private float InvinciblityFrames = 5f;

        //Determines when the player can see they have IFrames
        private bool ShowInvincibility;

        //References Player Materials
        private Renderer playerMesh;

        public GameObject PlayerMeshObj;

        private void Start()
        {
            //References the Mesh Renderer
            //playerMesh = PlayerCharacterRef.GetComponentInChildren<SkinnedMeshRenderer>();
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
        private IEnumerator playerDeathSequence()
        {
            //Play death animation

            //Freeze player controls
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = false;

            //Changes the player's tag so he cannot be hit
            PlayerCharacterRef.tag = "Invincible";

            //Calls the death particles function
            PlayerCharacterRef.GetComponent<RespawnParticles>().StartRespawnIEnum();

            //Deactivates the mesh renderer
            //playerMesh.enabled = false;

            PlayerMeshObj.SetActive(false);

            Debug.Log("Death Sequence Started.");
            Debug.Log("Player Is Invincible");

            yield return new WaitForSeconds(AnimationTime);

            //Deactivates the mesh renderer
            //playerMesh.enabled = true;

            PlayerMeshObj.SetActive(true);

            Debug.Log("Animation Over");

            //Unfreezes player controls
            PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = true;

            //Starts Invincibilty Frames Coroutine
            StartCoroutine(IFrames());

            //Ends this Coroutine
            StopCoroutine(playerDeathSequence());
        }

        /// <summary>
        /// Coroutine giving the player invincibility frames
        /// </summary>
        /// <returns></returns>
        private IEnumerator IFrames()
        {
            ShowInvincibility = true;
            
            //Starts the TogglePlayer Coroutine
            StartCoroutine(TogglePlayer());

            //The player is still invincible
            yield return new WaitForSeconds(InvinciblityFrames);

            ShowInvincibility = false;

            Debug.Log("Invincibility Over");

            //Resets the player's tag, allowing him to get hit again
            PlayerCharacterRef.tag = "Player";
        }

        /// <summary>
        /// Responsible for toggling the player's mesh on / off, allowing the player to see when Invincibility Frames are active
        /// </summary>
        /// <returns></returns>
        private IEnumerator TogglePlayer()
        {
            //Time to wait before changing mesh state
            float TimeToWait = 0.5f;

            while (ShowInvincibility == true)
            {
                //Deactivates the mesh renderer
                //playerMesh.enabled = false;
                PlayerMeshObj.SetActive(false);

                yield return new WaitForSeconds(TimeToWait);

                //Reactivates the mesh renderer
                //playerMesh.enabled = true;
                PlayerMeshObj.SetActive(true);

                yield return new WaitForSeconds(TimeToWait);
            }

            //If ShowInvincibility is false, end this Coroutine
            StopCoroutine(TogglePlayer());
        }

        private void CheckPlayerDeath()
        {
            if (playerLives <= 0)
            {
                isPlayerDead = true;
            }
        }
    }
}
