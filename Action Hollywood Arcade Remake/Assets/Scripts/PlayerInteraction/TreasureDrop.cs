using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// This script handles instantiating treasure prefabs infront of the object the script is held on.
    /// It drops the treasure in the direction the player is in. I do this so the treasure won't end up inside a wall.
    /// 
    /// Treasure triggers are scaled to 1.005 on all axis. This is because for some reason the ray doesn't always pick up the trigger.
    /// 
    /// **Potential Issue: Player moves down / to the side and the prefab is instantiated diagonally, half in a wall.**
    /// 
    /// </summary>
    public class TreasureDrop : MonoBehaviour
    {
        //References the player character
        public GameObject PlayerCharacter;

        //References the prefab to instantiate
        public GameObject TreasurePrefab;

        //References the distance the prefab will spawn from the player.
        public float SpawnDistance = 1;

        public void TreasureOnRayHit()
        {
            //When function is called, it will grab the player's last position.
            //It will also grab the direction the player was last facing (attack direction)
            Vector3 PlayerPosition = PlayerCharacter.transform.position;
            Vector3 PlayerDirection = PlayerCharacter.transform.forward;

            Vector3 SpawnPosition = PlayerPosition + PlayerDirection * SpawnDistance;

            //Instantiate Object
            Instantiate(TreasurePrefab, SpawnPosition, Quaternion.Euler(0,0,0));

            Debug.Log("Treasure Spawned at: " + SpawnPosition);
        }
    }
}
