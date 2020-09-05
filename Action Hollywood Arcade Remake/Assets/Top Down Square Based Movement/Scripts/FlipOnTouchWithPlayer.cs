using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script flips the tile when it is triggered by an obejct with the tag "Player"
    /// </summary>
    public class FlipOnTouchWithPlayer : MonoBehaviour
    {


        //How long the flip animation should go for
        [SerializeField] private float duration = 1;

        float timer = 0;
        bool isRotating;
        Quaternion startRotation;
        Quaternion endRotation;

        private void Start()
        {
            startRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            endRotation = Quaternion.Euler(new Vector3(180, 0, 0));
        }
        private void Update()
        {
            //Once the rotating boolean is triggered flip the parent of the trigger to the end rotation 
            //(in this case hard-code to be upside down - but this could be improved with a variable)
            if (isRotating)
            {
                timer += Time.deltaTime / duration;
                this.transform.parent.rotation = Quaternion.Lerp(startRotation, endRotation, timer);
            }

            //Once the animation has been complete - destroy this script so it does not keep running
            if (timer > 1)
            {
                Destroy(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //If the object this script is attached to (which has a collider marked as a trigger) hits something 
            //with a tag of "Player" it will start the flip animation by toggling on a boolean
            if (other.gameObject.CompareTag("Player"))
            {
                //Set the parent to the trigger gameobject to also be a trigger so that when it flips
                //it does not do collisions with any of the other objects - like the player and the enemies
                this.transform.parent.GetComponent<Collider>().isTrigger = true;
                isRotating = true;
            }
        }
    }
}