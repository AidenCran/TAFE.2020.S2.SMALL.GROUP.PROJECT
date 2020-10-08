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
        public GameObject BoulderObject;

        private int RayCastDist = 6;
        RaycastHit hitPoint;

        void Update()
        {
            /// <summary>
            /// These statements shoot rays out from the object in 4 directions. If the rays hit the player they activate the BoulderAttack script, else they do nothing.
            /// </summary>

            //This way is more ugly than I wanted. However this allows me to easily call an attack script that just moves the Boulder in the direction it was tripped.


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttackForward
                    this.GetComponent<BoulderAttack>().BoulderAttackForward();

                    Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttackBackwards
                    this.GetComponent<BoulderAttack>().BoulderAttackBackward();

                    Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttackRight
                    this.GetComponent<BoulderAttack>().BoulderAttackRight();

                    Destroy(this);
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitPoint, RayCastDist))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.Log("Hit Player");
                    //Call BoulderAttackLeft
                    this.GetComponent<BoulderAttack>().BoulderAttackLeft();

                    Destroy(this);
                }
            }
        }
    }
}