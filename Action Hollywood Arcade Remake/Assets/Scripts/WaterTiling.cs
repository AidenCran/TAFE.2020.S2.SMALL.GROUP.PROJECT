using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020
    /// 
    /// This simply allows the background to smoothly tile and move downwards.
    /// It modifies the height variable under the Tiled section.
    /// 
    /// Directions:
    /// Place script onto sprite in question
    /// Set Draw Mode to Tiled (I should do that in the start function, but whatever.
    /// </summary>
    public class WaterTiling : MonoBehaviour
    {
        Vector2 currentTiledSize;

        //References when the tile cycle repeats
        //Basically move the sprite's height down till it tiles, and put the result here
        float EndOfTileCycle = 14.4f; //MUST CHANGE THIS TO MATCH, UNSURE IF THERE IS A WAY TO CALCULATE

        public void Start()
        {
            //Sets the default size of the texture
            currentTiledSize.x = this.GetComponent<SpriteRenderer>().size.x;
            currentTiledSize.y = this.GetComponent<SpriteRenderer>().size.y;
        }
        public void Update()
        {
            this.GetComponent<SpriteRenderer>().size = currentTiledSize;

            if (currentTiledSize.y <= EndOfTileCycle)
            {
                currentTiledSize.y += 0.5f * Time.deltaTime;
            }
            else
            {
                currentTiledSize.y = 4.8f;
            }
        }
    }
}
