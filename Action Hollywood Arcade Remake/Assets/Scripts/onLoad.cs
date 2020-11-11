using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 7/11/2020
    /// Last Edited: 11/11/2020
    /// 
    /// This script makes it that when the player first loads an instance of the game, it deletes all game data.
    /// </summary>
    public class onLoad : MonoBehaviour
    {
        private void Awake()
        {
            // Deletes current Data
            SaveManager.DeleteData();
        }
    }
}
