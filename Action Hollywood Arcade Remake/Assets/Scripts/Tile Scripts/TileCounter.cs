using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

/// <summary> 
/// This is attached to the tile prefab. On start every tile adds 1 to the total.
/// This gives us the total amount of tiles in the scene.
/// </summary>
namespace AidensWork
{
    public class TileCounter : MonoBehaviour
    {
        public void Start()
        {
            TileTracker.Instance.TilesRemaining += 1;
        }
    }
}