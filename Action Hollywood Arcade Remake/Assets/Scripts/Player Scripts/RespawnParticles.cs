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

            DeathParticleRef.Play();

            yield return new WaitForSeconds(WaitTime);

            DeathParticleRef.Stop();

            StartCoroutine(RespawnParticleSystem());
        }

        public IEnumerator RespawnParticleSystem()
        {
            float WaitTime = 3f;

            RespawnParticleRef.Play();

            yield return new WaitForSeconds(WaitTime);

            RespawnParticleRef.Stop();
        }
    }
}
