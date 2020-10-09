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
        private int RayCastDist = 10;
        RaycastHit hitPoint;

        void Update()
        {
            /// <summary>
            /// These statements shoot rays out from the object in 4 directions. If the rays hit the player they activate the BoulderAttack script, else they do nothing.
            /// </summary>

            //This way is way more ugly than I wanted. However this allows me to easily call an attack script that just moves the Boulder in the direction it was tripped.
            //Plus I don't know how to put mutliple transform directions in 1 statement. I tried an array, but the syntax failed.


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitPoint, RayCastDist))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green);
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player - Forward");
                    //Call BoulderAttackForward
                    //this.GetComponent<BoulderAttack>().BoulderAttackForward();

                    //Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player - Backward");
                    //Call BoulderAttackBackwards
                    //this.GetComponent<BoulderAttack>().BoulderAttackBackward();

                    //Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player - Right");
                    //Call BoulderAttackRight
                    //this.GetComponent<BoulderAttack>().BoulderAttackRight();

                    //Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player - Left");
                    //Call BoulderAttackLeft
                    //this.GetComponent<BoulderAttack>().BoulderAttackLeft();

                    //Destroy(this);
                }
            }
        }
    }
}