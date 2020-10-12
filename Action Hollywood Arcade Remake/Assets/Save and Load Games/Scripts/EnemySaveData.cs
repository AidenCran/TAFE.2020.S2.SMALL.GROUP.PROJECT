using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script stores data. Notice it does not inherit from Monobehaviour and is Serializable
    [System.Serializable]
    public class EnemySaveData : MonoBehaviour
    {
        [SerializeField] string enemyName;
        [SerializeField] int health;
        [SerializeField] int maxHealth;

        public Vector3 storedPosition;
        public Vector3 storedRotation;

        public EnemySaveData()
        {
            health = maxHealth;
        }


        public void StorePositionAndRotation()
        {
            storedPosition = this.transform.position;
            storedRotation = this.transform.rotation.eulerAngles;
        }

        public void SpawnAtPositionAndRotation()
        {
            this.transform.position = storedPosition = this.transform.position;
            this.transform.rotation = Quaternion.Euler(storedRotation);
        }
    }
}