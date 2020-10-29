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

        public LayerMask layer_mask;

        void FixedUpdate()
        {
            /// <summary>
            /// These statements shoot rays out from the object in 4 directions. If the rays hit the player they activate the BoulderAttack script, else they do nothing.
            /// </summary>

            ForwardRayCast();

            BackRayCast();

            RightRayCast();

            LeftRayCast();
        }

        void ForwardRayCast()
        {
            Debug.DrawRay(transform.position, transform.forward * RayCastDist, Color.green);
            if (Physics.Raycast(transform.position, transform.forward, out hitPoint, RayCastDist, layer_mask))
            {
                //Debug.Log(hitPoint.transform.tag);

                if (hitPoint.collider.tag == "Player")
                { 
                    Debug.Log("Hit Player - Forward");
                    //Call BoulderAttackForward
                    this.GetComponent<BoulderAttack>().BoulderAttackForward();

                    Destroy(this);
                }
            }
        }

        void BackRayCast()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitPoint, RayCastDist, layer_mask))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    Debug.Log("Hit Player - Backward");
                    //Call BoulderAttackBackwards
                    //this.GetComponent<BoulderAttack>().BoulderAttackBackward();

                    //Destroy(this);
                }
            }
        }

        void RightRayCast()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitPoint, RayCastDist, layer_mask))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    Debug.Log("Hit Player - Right");
                    //Call BoulderAttackRight
                    //this.GetComponent<BoulderAttack>().BoulderAttackRight();

                    //Destroy(this);
                }
            }
        }

        void LeftRayCast()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitPoint, RayCastDist, layer_mask))
            {
                if (hitPoint.collider.tag == "Player")
                {
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    Debug.Log("Hit Player - Left");
                    //Call BoulderAttackLeft
                    //this.GetComponent<BoulderAttack>().BoulderAttackLeft();

                    //Destroy(this);
                }
            }
        }
    }
}