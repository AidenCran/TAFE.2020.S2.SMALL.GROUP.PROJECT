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
    public class BoulderRoll : MonoBehaviour
    {
        Rigidbody BoulderRigidBody;
        public float speed = 1f;

        [SerializeField] private LayerMask wallLayer;

        void Start()
        {
            BoulderRigidBody = this.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            BoulderRollForward();

            if (Physics.Raycast(this.transform.position, this.transform.forward, 1f, wallLayer))
            {
                StartCoroutine(BreakAni());
            }
        }

        public void BoulderRollForward()
        {
            //Go Forward
            BoulderRigidBody.velocity = transform.forward * speed;
            Debug.Log("Going Forward");

            //Break on collision

            //If player do ***
            //Else do ***
        }

        private IEnumerator BreakAni()
        {
            float WaitTime = 1.5f;

            //Stops the object from moving
            speed = 0;

            //Break Animation / Particles
            Debug.Log("Oh no... Im breaking.. So sad /s");

            //Waits 2 seconds
            yield return new WaitForSeconds(WaitTime);

            //Destroys gameobject
            Destroy(gameObject);
        }
    }
}
