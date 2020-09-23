using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class PlayerAttackActivate : MonoBehaviour
    {
        private int RayCastDist = 1;
        RaycastHit hitPoint;

        private void Update()
        {
            playerAttack();
        }

        void playerAttack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Play Attack Sound

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitPoint, RayCastDist))
                {
                    if (hitPoint.collider.tag == "Enemy")
                    {
                        Debug.Log("Hit Enemy");
                        //Call PlayerAttack
                    }

                    if (hitPoint.collider.tag == "Treasure")
                    {
                        Debug.Log("Hit Treasure");
                        //Call TreasureScript
                    }

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
