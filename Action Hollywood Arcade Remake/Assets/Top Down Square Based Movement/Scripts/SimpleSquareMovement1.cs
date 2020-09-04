using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script handles movement based on a square tile movement mode.
    ///                It does some raycasts to check if it can even move in the direction
    ///                and also smoothly lerps to the tile in front of the general movement direction
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class SimpleSquareMovement : MonoBehaviour
    {
        private CharacterController controller;

        [SerializeField] private float playerSpeed = 2.0f;

        private float xMovementAmount;
        private float zMovementAmount;
        [SerializeField] private Vector3 totalMovementVector;

        private bool isLerping = false;

        [Tooltip("This is the layer to use on the tiles only")]
        //This layermask is for the tiles only (make a layer called "Tiles" or something similar and apply it to your tile gameobject
        //This just optimises the raycasts and stops them hitting everything in the scene
        [SerializeField] private LayerMask tileLayer;
        //This will be the location the raycasts going forward of the player will update 
        // - it is the position the player will lerp to once there are no inputs
        [SerializeField] private Vector3 nextStop;

        private float timer = 0;
        //Lerp duration
        [SerializeField] private float gotoNextTileAnimationDuration = 2;

        Ray rayThatExtendJustIntoNext1mSquareArea;
        Ray rayThatExtendJustBeforeNext1mSquareArea;

        private void Start()
        {
            //Cache a reference to the CharacterController component on the same object that this script is attached to
            controller = gameObject.GetComponent<CharacterController>();
        }

        private bool allowDiagonals = false;

        private void Update()
        {

            //If already pressing a key for the left/right then do not allow to input forward/back
            //If already pressing a key for the forward/back then do not allow to input left/right

            zMovementAmount = Input.GetAxis("Vertical");
                xMovementAmount = Input.GetAxis("Horizontal");

            totalMovementVector = new Vector3(xMovementAmount, 0, zMovementAmount);

            if (!allowDiagonals)
            {
                if (Mathf.Abs(totalMovementVector.x) > Mathf.Abs(totalMovementVector.z))
                {
                    totalMovementVector.z = 0;
                }
                else
                {
                    totalMovementVector.x = 0;
                }
            }


            

            //(Input.GetButtonDown("Horizontal") && !Input.GetButton("Vertical")) || (Input.GetButtonDown("Vertical") && !Input.GetButton("Horizontal"))
            //Toggle lerping to deactivate if inputs are being applied
            if ((Input.GetButtonDown("Horizontal") && !Input.GetButton("Vertical")) || (Input.GetButtonDown("Vertical") && !Input.GetButton("Horizontal")))
            {
                SetRotationBasedOnInputDirection();
                isLerping = false;
                controller.transform.position = nextStop;
                timer = 0;
            }

            //Toggle lerping to activate if inputs are not being applied
            if ((Input.GetButtonUp("Horizontal") && !Input.GetButton("Vertical"))  || (Input.GetButtonUp("Vertical") && !Input.GetButton("Horizontal")))
            {
                isLerping = true;
                GetSquareToEndOn();
            }

            //If lerping then deactive the CharacterController and override it with a lerp of the transfrom
            if (isLerping)
            {
                controller.enabled = false;
                LerpToNextPosition(controller.transform.position, nextStop);
            }
            else
            {
                if (IsSquareInThatDirection())
                {
                    controller.enabled = true;
                    controller.Move(totalMovementVector * Time.deltaTime * playerSpeed);

                }
            }
        }

        /// <summary>
        /// This will rotate the object towards the direction the player inputs are being made.
        /// </summary>
        private void SetRotationBasedOnInputDirection()
        {
            if (zMovementAmount > 0)
            {
                SetTransformRotationY(0);
            }
            else if (zMovementAmount < 0)
            {
                SetTransformRotationY(180);
            }
            else if (xMovementAmount < 0)
            {
                SetTransformRotationY(-90);
            }
            else if (xMovementAmount > 0)
            {
                SetTransformRotationY(90);
            }
        }

        /// <summary>
        /// Used to determine the square to lerp to once the user releases the inputs
        /// </summary>
        void GetSquareToEndOn()
        {
            RaycastHit close1mTileHitInfo;
            if (Physics.Raycast(rayThatExtendJustBeforeNext1mSquareArea, out close1mTileHitInfo, 3, tileLayer))
            {
                Debug.Log(close1mTileHitInfo.collider.gameObject.name);
                nextStop = close1mTileHitInfo.collider.gameObject.transform.position;
                nextStop.y = 0;
                //Color tile - just for testing
                //ray2hitInfo.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }

        /// <summary>
        /// Use to determine if the player can move ahead in the direction of the user inputs
        /// </summary>
        /// <returns></returns>
        bool IsSquareInThatDirection()
        {
            RaycastHit next1mTileHitInfo;
            if (Physics.Raycast(rayThatExtendJustIntoNext1mSquareArea, out next1mTileHitInfo, 3, tileLayer))
            {
                //Color tile - just for testing
                //rayhitInfo.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                return true;
            }

            return false;
        }


        private void FixedUpdate()
        {
            //Create two rays - 
            //              both start at the middle of the player, 
            //              one reaching just into the next square (1m) area, and 
            //              one staying just inside the current square (1m) area
            //transform.TransformDirection(Vector3.forward ) is the same as transform.forward
            rayThatExtendJustIntoNext1mSquareArea = new Ray(this.transform.position + Vector3.up, transform.TransformDirection(Vector3.forward + Vector3.down * 1.8f));
            rayThatExtendJustBeforeNext1mSquareArea = new Ray(this.transform.position + Vector3.up, transform.TransformDirection(Vector3.forward + Vector3.down * 2.0f));

            //These are just for debugging can be remove in final
            Debug.DrawRay(rayThatExtendJustIntoNext1mSquareArea.origin, rayThatExtendJustIntoNext1mSquareArea.direction * 2, Color.yellow);
            Debug.DrawRay(rayThatExtendJustBeforeNext1mSquareArea.origin, rayThatExtendJustBeforeNext1mSquareArea.direction * 2, Color.red);
        }


        //Quickly snap the object (in this case the player) to a certain direction
        //You could do this smoothly but in this kind of game you want it snappy and instant
        void SetTransformRotationY(float yRotation)
        {
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        /// <summary>
        /// Based on the next tile in front of the player position (found using Raycasts)
        /// When the player releases the inputs, lerp to the next available tile
        /// </summary>
        /// <param name="startLocation"></param>
        /// <param name="endLocation"></param>
        void LerpToNextPosition(Vector3 startLocation, Vector3 endLocation)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime / gotoNextTileAnimationDuration;
                controller.transform.position = Vector3.Lerp(startLocation, endLocation, timer);
            }
            else
            {
                isLerping = false;
                timer = 0;
            }
        }
    }
}