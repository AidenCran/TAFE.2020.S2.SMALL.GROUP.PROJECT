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
    /// </summary>
    public class TreasureDrop : MonoBehaviour
    {
        //References the player character
        public GameObject PlayerCharacter;

        //References the prefab to instantiate
        public GameObject TreasurePrefab;

        //Specifies how many objects will spawn
        public int AmountToSpawn = 1;

        //Defines the amount of times you can hit the treasure until it breaks
        public int TreasureDurability = 3;

        public void TreasureOnRayHit()
        {
            //When function is called, it will grab the player's last position
            Vector3 SpawnPosition = PlayerCharacter.transform.position;

            SpawnPosition.y += Random.Range(1,2);

            if (TreasureDurability != 0)
            {
                for (int i = 0; i < AmountToSpawn; i++)
                {
                    //Instantiate Object
                    Instantiate(TreasurePrefab, SpawnPosition, Quaternion.Euler(0, 0, 0));

                    Debug.Log("Treasure Spawned at: " + SpawnPosition);
                }
                
                //Removes durability 
                TreasureDurability -= 1;
                Debug.Log("Treasure Now Has " + TreasureDurability + " Durability");
            }
            else
            {
                //Play Sound?
                //Play Animation?
                //Or Spawn Particle System

                //Increases Brick value by 1
                ScoreCalc.Instance.BrickAmountPickedUp++;

                //If Durability == 0, destroy the game object.
                Destroy(gameObject);
            }
        }
    }
}
