using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 26/10/2020
    /// Last Edited:
    /// 
    /// Provides hoving movement to objects, mainly score objects
    /// </summary>
    public class ObjectHover : MonoBehaviour
    {
        Transform thisTransform;
        Vector3 startingPosition;
        Vector3 currentPosition;
        public float frequency = 1f;
        public float amplitude = 0.5f;
        public float xAngle, yAngle, zAngle;

        private void Start()
        {
            thisTransform = this.GetComponent<Transform>();
            startingPosition = thisTransform.position;
            currentPosition = startingPosition;

            yAngle = 0.8f;
        }

        void Update()
        {
            if (PauseMenu.Instance.GamePaused == false)
            {
                currentPosition.y = startingPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
                thisTransform.position = currentPosition;
                thisTransform.Rotate(xAngle, yAngle, zAngle, Space.World);
            }
        }
    }
}
