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

        public int TilesRemaining;
        public int TileThreshold = 5;
        public bool lastTiles;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (TilesRemaining < TileThreshold && lastTiles == false)
            {
                lastTiles = true;
                this.gameObject.GetComponent<LastTiles>().LastTileFunction();
            }
        }

        //public void LastTiles()
        //{
        //    //Move this method to another script. This script just tracks the tiles.
        //    //Another script handles the LastTiles function e.g. changing material of the remaining tiles etc.
        //}
    }
}
