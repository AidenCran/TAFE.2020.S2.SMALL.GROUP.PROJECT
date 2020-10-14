Tile Counter Script
===================

## Quick Description

This script determines how many tiles there are in the scene on start.

## Code Snippet

```

        {
            TileTracker.Instance.TilesRemaining += 1;
        }

```

### How it works

Each tile prefab has this script attached. On start it increases the ```TilesRemaining``` Variable by one.

This is called # amount of times, giving us the total amount of tiles per level.