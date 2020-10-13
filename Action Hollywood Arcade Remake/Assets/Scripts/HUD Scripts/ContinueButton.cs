using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 13/10/2020
    /// Last Edited:
    /// 
    /// This script now handles both loading the last save, and deactivating the button if there is no save.
    /// It references the GameNavigation script to do the actual loading, while it checks if the conditions are met here.
    /// </summary>
    public class ContinueButton : MonoBehaviour
    {
        PlayerData pd;

        string SceneToLoad;

        public GameObject GameNavigationReference;

        private void Start()
        {
            pd = SaveManager.Load();

            //Checks if there is something written in the playerLevel field
            if (string.IsNullOrWhiteSpace(pd.CurrentLevel))
            {
                this.gameObject.GetComponent<Button>().interactable = false;
                Debug.Log("String Is Null");
            }
        }

        public void ContinueLastSave()
        {
            if (!string.IsNullOrWhiteSpace(pd.CurrentLevel))
            {
                //Loads data (Again just in case)
                pd = SaveManager.Load();

                try
                {
                    //References the PlayerData for the current level
                    SceneToLoad = pd.CurrentLevel;

                    //Loads the current level when called
                    GameNavigationReference.GetComponent<GameNavigation>().ChangeScene(SceneToLoad);
                }
                catch (NullReferenceException nullError)
                {
                    Debug.Log("Null Error. Check pd.Current Level.");
                    Debug.LogError("Not Loaded" + nullError.ToString());
                }

            }
            else
            {
                Debug.Log("pd.CurrentLevel is Null / White Space");
            }
        }
    }
}
