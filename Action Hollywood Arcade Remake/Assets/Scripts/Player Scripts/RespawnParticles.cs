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
    public class RespawnParticles : MonoBehaviour
    {
        public ParticleSystem DeathParticleRef;
        public ParticleSystem RespawnParticleRef;

        public void StartRespawnIEnum()
        {
            StartCoroutine(RespawnSystem());
        }

        public IEnumerator RespawnSystem()
        {
            float WaitTime = 3f;

            //Starts Particle System
            DeathParticleRef.Play();

            //Waits 
            yield return new WaitForSeconds(WaitTime);

            //Stops Particle System
            DeathParticleRef.Stop();

            //Continues to respawn Coroutine
            StartCoroutine(RespawnParticleSystem());
        }

        public IEnumerator RespawnParticleSystem()
        {
            float WaitTime = 5f;

            RespawnParticleRef.Play();

            yield return new WaitForSeconds(WaitTime);

            RespawnParticleRef.Stop();
        }
    }
}
