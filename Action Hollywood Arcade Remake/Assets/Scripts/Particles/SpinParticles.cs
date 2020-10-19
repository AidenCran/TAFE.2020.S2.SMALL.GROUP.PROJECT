using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 19/10/2020
    /// Last Edited:
    /// 
    /// Place this ontop of the particle system of choice. It will rotate it at a designated speed.
    /// </summary>
    public class SpinParticles : MonoBehaviour
    {
        public Vector3 Speed;

        private void Update()
        {
            transform.Rotate(Speed * Time.deltaTime);
        }
    }
}
