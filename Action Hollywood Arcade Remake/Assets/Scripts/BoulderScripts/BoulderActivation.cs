using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// This script will determine when the boulder can see the player. If it can, it will call the boulder attack script.
    /// Initially I wanted to use raycasting from the boulder to determine if the player comes in range. 
    /// This would be better for the long run
    /// </summary>
    public class BoulderActivation : MonoBehaviour
    {
        private int RayCastDist = 5;
        RaycastHit hitPoint;

        void Update()
        {
            //TEMP FIX. Untill I figure out how to shoot rays from multiple directions in a single statement, this will stick.
            //I saw someone use an array for the directions, so I'll look into it~

            /// <summary>
            /// These statements shoot rays out from the object in 4 directions. If the rays hit the player they activate the BoulderAttack script, else they do nothing.
            /// </summary>
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttack
                    //DestroyThisScript
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttack
                    //DestroyThisScript
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttack
                    //DestroyThisScript
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttack
                    //DestroyThisScript
                }
            }
        }
    }
}