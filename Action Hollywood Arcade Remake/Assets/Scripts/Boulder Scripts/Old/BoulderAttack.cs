using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    public class BoulderAttack : MonoBehaviour
    {
        /// <summary>
        /// When the Boulder Activation script hits a player, it will execute the below function corrosponding to the direction of the player.
        /// This is a more ugly way to do it, but for now it works.
        /// </summary>

        Rigidbody BoulderRigidBody;
        
        public float speed = 5f;

        public bool isForward;
        public bool isBackward;
        public bool isRight;
        public bool isLeft;

        void Start()
        {
            BoulderRigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (isForward == true)
            {
                //Go Forward
                BoulderRigidBody.velocity = transform.forward * speed;
                Debug.Log("Going Forward");
                //Break on collision
                //If player do ***
                //Else do ***
            }

            if (isBackward == true)
            {
                //Go Forward
                BoulderRigidBody.velocity = -transform.forward * speed;
                Debug.Log("Going Backward");
                //Break on collision
                //If player do ***
                //Else do ***
            }

            if (isRight == true)
            {
                //Go Forward
                BoulderRigidBody.velocity = transform.right * speed;
                Debug.Log("Going Right");
                //Break on collision
                //If player do ***
                //Else do ***
            }

            if (isLeft == true)
            {
                //Go Forward
                BoulderRigidBody.velocity = -transform.right * speed;
                Debug.Log("Going Left");
                //Break on collision
                //If player do ***
                //Else do ***
            }
        }

        public void BoulderAttackForward()
        {
            isForward = true;
        }

        public void BoulderAttackBackward()
        {
            isBackward = true;
        }

        public void BoulderAttackRight()
        {
            isRight = true;
        }

        public void BoulderAttackLeft()
        {
            isLeft = true;
        }
    }
}

