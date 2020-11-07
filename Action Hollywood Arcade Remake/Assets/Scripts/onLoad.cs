using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 7/11/2020
    /// Last Edited:
    /// 
    /// This script makes it that when the player first loads an instance of the game, it deletes all game data.
    /// </summary>
    public class onLoad : MonoBehaviour
    {
        public PlayerData pd;

        private void Awake()
        {
            pd = SaveManager.Load();

            if (pd.LoadedFirstScene == false)
            {
                //Deletes current Data
                SaveManager.DeleteData();

                // Defines that the scene has been loaded
                pd.LoadedFirstScene = true;
            }
        }
    }
}
