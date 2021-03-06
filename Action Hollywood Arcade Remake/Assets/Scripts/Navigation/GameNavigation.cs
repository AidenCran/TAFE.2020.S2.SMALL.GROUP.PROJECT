﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020 (Last Edited)
    /// 
    /// This script handles changing scenes.
    /// On start the script loads data from the database. Mainly in regards to the latest level reached.
    /// This determines what level the continue function will load.
    /// </summary>
    public class GameNavigation : MonoBehaviour
    {
        PlayerData pd;

        public void ChangeScene(string SceneToLoad)
        {
            //Changes scene to the specified scene
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        public void RestartButton()
        {
            pd = SaveManager.Load();

            //Loads last level
            SceneManager.LoadSceneAsync(pd.CurrentLevel);
        }

        public void QuitGame()
        {
            //Deletes current Data
            SaveManager.DeleteData();

            //Exits Game
            Application.Quit();
        }
    }
}