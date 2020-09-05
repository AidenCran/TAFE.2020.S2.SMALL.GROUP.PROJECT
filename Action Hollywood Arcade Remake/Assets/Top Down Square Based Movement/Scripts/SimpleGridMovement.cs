using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;
using UnityEngine.Events;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script handles movement based on a square tile grid movement mode.
    ///                It does some raycasts to check if it can even move in the direction
    ///                and also smoothly lerps to the tile in front of the general movement direction
    /// Modified from: http://wiki.unity3d.com/index.php?title=GridMove
    /// </summary>
    public class SimpleGridMovement : MonoBehaviour
    {
        private enum State
        {
            Moving,
            Idle
        };
        [SerializeField] private float movementSpeed = 3f;
        private int gridSize = 1;
        private float movementMultiplier;

        //Give the developer the option to do 8 way movement or just 4 way movement
        [SerializeField] private bool allowDiagonalMovement = false;
        private bool correctDiagonalSpeed = true;

        private Vector3 userInput;
        //This layermask is for the walls only (make a layer called "Walls" or something similar and apply it to your wall gameObjects
        //This just optimises the raycasts and stops them hitting everything in the scene
        [SerializeField] private LayerMask wallLayer;
        private Vector3 startPosition;
        private Vector3 endPosition;

        private bool isMoving = false;
        private float timer;

        [Space(15)]
        [Header("Events Based On Movement")]

        //Unity Events exposed to the Unity Editor so the developer can assign things to them - like an Animation Script changing boolean states
        [SerializeField] UnityEvent OnMove;
        [SerializeField] UnityEvent OnIdle;

        CharacterController controller;

        //Store current state - could be used for other things like Attack, Death etc.
        State currentState = State.Idle;

        private void Start()
        {
            //Cache a reference to the CharacterController component on the same object that this script is attached to
            //This script mostly moves using the Transform not the CharacterController.Move() method but could be improved
            controller = this.GetComponent<CharacterController>();
        }

        public void Update()
        {
            //If the user presses a movement input, and the state is not already moving, then fire off an event and change the state
            if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal")) && currentState != State.Moving)
            {
                currentState = State.Moving;
                OnMove?.Invoke();
            }

            //If the user releaases all inputs, and the state is not already idle, then fire off an event and change the state
            if ((!Input.GetButton("Vertical") && !Input.GetButton("Horizontal")) && currentState != State.Idle)
            {
                currentState = State.Idle;
                OnIdle?.Invoke();
            }

            //If not moving then get inputs and start the smooth lerping Coroutine
            if (!isMoving)
            {
                userInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

                //If already pressing a key for the forward/back then do not allow to input left/right. 
                //Precedence order is: Forward, Back, Right, Left
                if (!allowDiagonalMovement)
                {
                    if (Mathf.Abs(userInput.x) > Mathf.Abs(userInput.z))
                    {
                        userInput.z = 0;
                    }
                    else
                    {
                        userInput.x = 0;
                    }
                }

                if (userInput != Vector3.zero)
                {
                    StartCoroutine(MoveTransformWithGridSnapping(controller.transform));
                }
            }
        }

        //Quickly snap the object (in this case the player) to a certain direction
        //You could do this smoothly but in this kind of game you want it snappy and instant
        void SetTransformRotationY(float yRotation)
        {
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        /// <summary>
        /// Every frame run this method to smoothly move the character to the next nearest grid square.
        /// It will also rotate the character in the direction the inputs are made.
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public IEnumerator MoveTransformWithGridSnapping(Transform transform)
        {
            isMoving = true;
            startPosition = transform.position;
            timer = 0;

            if (System.Math.Sign(userInput.z) > 0 && System.Math.Sign(userInput.x) < 0) { SetTransformRotationY(-45); }
            else if (System.Math.Sign(userInput.z) > 0 && System.Math.Sign(userInput.x) > 0) { SetTransformRotationY(45); }
            else if (System.Math.Sign(userInput.z) < 0 && System.Math.Sign(userInput.x) < 0) { SetTransformRotationY(225); }
            else if (System.Math.Sign(userInput.z) < 0 && System.Math.Sign(userInput.x) > 0) { SetTransformRotationY(135); }
            else if (System.Math.Sign(userInput.x) < 0) { SetTransformRotationY(-90); }
            else if (System.Math.Sign(userInput.x) > 0) { SetTransformRotationY(90); }
            else if (System.Math.Sign(userInput.z) < 0) { SetTransformRotationY(180); }
            else if (System.Math.Sign(userInput.z) > 0) { SetTransformRotationY(0); }

            //If, 1m in front of the object, another object is detected with a particular layername 
            // then stop input from being used to move object
            if (Physics.Raycast(this.transform.position, this.transform.forward, 1f, wallLayer))
            {
                userInput.x = 0;
                userInput.z = 0;
            }

            endPosition = new Vector3(startPosition.x + System.Math.Sign(userInput.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(userInput.z) * gridSize);


            //Effectively input.normalized but used for lerping.  
            //If you did not do this the diagonal movement would be faster than the up/down/left/right movement
            if (allowDiagonalMovement && correctDiagonalSpeed && userInput.x != 0 && userInput.z != 0)
            {
                movementMultiplier = 0.7071f;
            }
            else
            {
                movementMultiplier = 1f;
            }

            //Over 1 second do a smooth transition of the gameObject position from the current postion to the endPosition
            while (timer < 1f)
            {
                timer += Time.deltaTime * (movementSpeed / gridSize) * movementMultiplier;
                transform.position = Vector3.Lerp(startPosition, endPosition, timer);
                yield return null;
            }

            isMoving = false;
            yield return 0;
        }
    }
}