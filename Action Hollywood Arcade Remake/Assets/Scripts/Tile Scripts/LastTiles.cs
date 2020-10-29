using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// 
    /// </summary>
    public class LastTiles : MonoBehaviour
    {
        public GameObject[] LevelTileReference; 

        public void LastTileFunction()
        {
            for (int i = 0; i < LevelTileReference.Length; i++)
            {
                if (LevelTileReference[i].GetComponent<TileCounter>().isFlipped == false)
                {
                    //Change Material / Add animation / Whatever I end up putting here
                    LevelTileReference[i].GetComponent<Renderer>().material.SetColor("_Color", Color.red);

                    //Starts the particle system
                    //LevelTileReference[i].GetComponentInChildren<ParticleSystem>().Play();

                    Debug.Log("Last Few Tiles. Go Get Em'");
                }
            }
        }
    }
}
