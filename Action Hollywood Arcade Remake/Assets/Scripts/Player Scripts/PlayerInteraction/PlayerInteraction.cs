using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class PlayerInteraction : MonoBehaviour
    {
        private int RayCastDist = 1;
        RaycastHit hitPoint;

        private void Update()
        {
            playerAttack();
        }

        void playerAttack()
        {
            //Checks if player attacks
            if (Input.GetButtonDown("Fire1"))
            {
                //Play Attack Sound
                //Play Attack Animation

                //Casts rays to determine if a collider that matches is hit
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitPoint, RayCastDist))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
                    //Debug.Log("Ray Drawn");

                    //Checks if collider is an enemy
                    if (hitPoint.collider.tag == "Enemy")
                    {
                        Debug.Log("Hit Enemy");
                        //Call PlayerAttack
                    }

                    //Checks if collider is treasure
                    if (hitPoint.collider.tag == "Treasure")
                    {
                        Debug.Log("Hit Treasure");
                        //Call TreasureScript
                        if (hitPoint.collider != null)
                        {
                            // Find the hit reciver (if existant) and call the method
                            var hitReciver = hitPoint.collider.gameObject.GetComponent<TreasureDrop>();
                            if (hitReciver != null)
                            {
                                hitReciver.TreasureOnRayHit();
                            }
                        }
                    }

                    //Checks if collider is a Boulder
                    if (hitPoint.collider.tag == "Boulder")
                    {
                        Debug.Log("Hit Boulder");
                        //Call BoulderAttack
                    }
                }
            }
        }
    }
}
