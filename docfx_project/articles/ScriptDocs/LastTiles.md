Last Tiles Function
===================

## Quick Description

This function alters the texture for all the unflipped tiles in the scene.

## Code Snippet

```

 public GameObject[] LevelTileReference; 

        public void LastTileFunction()
        {
            for (int i = 0; i < LevelTileReference.Length; i++)
            {
                if (LevelTileReference[i].GetComponent<TileCounter>().isFlipped == false)
                {
                    //Change Material / Add animation / Whatever I end up putting here
                    LevelTileReference[i].GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
                    Debug.Log("Last Few Tiles. Go Get Em'");
                }
            }
        }

```

### How it works

First we create a reference to all the tiles in the level. If we want to do this efficiently, we would automatically set this array with a "Findby--" feature. However that's not needed here.

When the function is called, it iterates through all the tiles and determines if the tile is flipped already. If they aren't the material is changed indicating that the these are the last few tiles.

Later this will be replaced with changing the texture instead of the material colour or something, however for now it just changes the colour.