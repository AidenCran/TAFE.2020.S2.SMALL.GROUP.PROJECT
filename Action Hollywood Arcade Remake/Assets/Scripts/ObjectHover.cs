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
        Transform thisTranform;
        Vector3 startingPosition;
        Vector3 currentPosition;
        private float frequency = 1f;
        private float amplitude = 0.5f;
        private float xAngle, yAngle, zAngle;

        private void Start()
        {
            thisTranform = this.GetComponent<Transform>();
            startingPosition = thisTranform.position;
            currentPosition = startingPosition;

            yAngle = 0.8f;
        }

        void Update()
        {
            //Use some basic trigonometry to do a natural looking wave motion
            //Note: you could do something similar on Z and X axis and get some cool effects
            currentPosition.y = startingPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
            thisTranform.position = currentPosition;
            thisTranform.Rotate(xAngle, yAngle, zAngle, Space.World);
        }
    }
}
