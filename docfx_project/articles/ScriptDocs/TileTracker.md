Tile Tracker Script
===================

## Quick Description

This script handles detecting how many tiles remain unflipped. Once that amount drops past the Threshold, it calls the Last Tiles Script.

## Code Snippet

```

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

        // Update is called once per frame
        void Update()
        {
            if (TilesRemaining < TileThreshold && lastTiles == false)
            {
                lastTiles = true;
                this.gameObject.GetComponent<LastTiles>().LastTileFunction();
            }
        }

```

### How it works

Firstly, this script is a Singleton. Being a Singleton, there will only ever be one instance of this script at any one time.

This script's only function is to determine how many tiles remain in the scene. Everytime the player flips over a tile, the ``` TilesRemaining ``` Variable is reduced by one.

The TilesRemaining Variable is increased by the amount of tiles in the scene on start. 

Refer to the TileCounter script for more info.

On Update, it checks if the tiles remaining have dropped past the Threshold. If it is and the function has not already been called, it calls the LastTileFunction.

Refer to the Last Tiles Script for more info.