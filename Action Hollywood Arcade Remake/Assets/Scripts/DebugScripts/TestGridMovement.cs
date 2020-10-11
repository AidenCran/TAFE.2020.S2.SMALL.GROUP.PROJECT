using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    ///  
    /// Temp Moving Script. Just lets me test the game without dealing with the dumb broken camera movement.
    /// Can walk through walls... and doesn't turn the character...
    /// </summary>
    public class TestGridMovement : MonoBehaviour
    {
        private bool isMoving;
        private Vector3 origPos, targetPos;
        private float timeToMove = 0.3f;

        //[SerializeField] private LayerMask wallLayer;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.forward));
            }

            if (Input.GetKey(KeyCode.A) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }

            if (Input.GetKey(KeyCode.S) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.back));
            }

            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }
        }

        private IEnumerator MovePlayer(Vector3 direction)
        {
            isMoving = true;

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = origPos + direction;

            ////If, 1m in front of the object, another object is detected with a particular layername 
            //// then stop input from being used to move object
            //if (Physics.Raycast(this.transform.position, this.transform.forward, 1f, wallLayer))
            //{
            //    isMoving = true;
            //}

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            isMoving = false;
        }
    }
}
