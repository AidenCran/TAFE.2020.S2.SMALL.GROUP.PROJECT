using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// This script is a singleton. It is only used in the scene once since it handles reading how many tiles remain.
    /// Every tile wakes to add +1 to the tilesRemaning Variable. When the player walks over the tile it substracts 1 from this number.
    /// When the remaining tiles are reduced to less than the threshold, then the LastTiles function is called and a bool is tripped.
    /// The bool lets us prevent the update function from calling the LastTiles function every frame until the remaining tiles is over the Threshold.
    /// </summary>
    public class TileTracker : MonoBehaviour
    {
        #region ---[ singleton code base ]---

        // Singleton Reference
        private static TileTracker _instance;
        public static TileTracker Instance { get { return _instance; } }

        // Setup Variables
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        [Tooltip ("Amount of Tiles Remaing Duh")]
        public int TilesRemaining;

        [Tooltip ("Amount of tiles left before the Last Tiles script is triggered.")]
        public int TileThreshold = 5;

        [Tooltip("Determines if Last Tiles has been triggered")]
        public bool lastTiles;

        void Update()
        {
            if (TilesRemaining < TileThreshold && lastTiles == false)
            {
                lastTiles = true;
                this.gameObject.GetComponent<LastTiles>().LastTileFunction();
            }
        }
    }
}
