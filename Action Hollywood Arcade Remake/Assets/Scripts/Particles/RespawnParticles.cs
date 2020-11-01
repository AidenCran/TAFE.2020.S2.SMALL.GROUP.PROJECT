using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 15/11/2020
    /// Last Edited: 1/11/2020
    /// 
    /// This script Handles the visual respawn sequence
    /// </summary>
    public class RespawnParticles : MonoBehaviour
    {
        // References the Particle System Object
        public ParticleSystem RevisedParticleSystem;

        // References the Death Vision Post Process Effect
        public GameObject DeathVision;

        public void StartRespawnIEnum()
        {
            // Calls the Respawn System
            // This Deals with the particles
            StartCoroutine(RespawnSystem());
        }

        public IEnumerator RespawnSystem()
        {
            // Selective WaitTimes
            float WaitTimeA = 6f;
            float WaitTimeB = 2f;

            //Starts Particle System
            //DeathParticleRef.Play();

            RevisedParticleSystem.Play();

            DeathVision.SetActive(true);

            // Waits
            yield return new WaitForSeconds(WaitTimeA);

            // Disables Particle System
            // It is disabled first due to it's trail effect
            RevisedParticleSystem.Stop();

            // Waits to disable the Vision till the IFrames have finished
            // Better way to do this would be to link this time to the time from PlayerLives 
            // OR set PlayerLives to wait for a return value from this to turn off IFrames (or Vise Versa)
            yield return new WaitForSeconds(WaitTimeB);

            // Disables Death Vision
            DeathVision.SetActive(false);
        }
    }
}
