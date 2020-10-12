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
    /// 
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] SpawnAreaBlocks;

        public GameObject EnemyPrefab;

        public int SpawnedAmount = 0;

        private void Awake()
        {
            while (SpawnedAmount <= 10)
            {
                for (int i = 0; i < SpawnAreaBlocks.Length && SpawnedAmount <= 10; i++)
                {
                    Vector3 SpawnTilePos = SpawnAreaBlocks[i].transform.position;
                    SpawnTilePos.y = 0;

                    int SpawnChance = Random.Range(1, 10);

                    if (SpawnChance == 1)
                    {
                        Instantiate(EnemyPrefab, SpawnTilePos, Quaternion.identity);
                        SpawnedAmount += 1;
                    }
                }
            }
        }
    }
}
