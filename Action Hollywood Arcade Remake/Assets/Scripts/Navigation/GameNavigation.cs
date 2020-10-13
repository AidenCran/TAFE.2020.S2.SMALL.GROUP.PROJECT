using System.Collections;
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
        //string SceneToLoad;
        //References the PlayerData
        public PlayerData pd;

        public void Start()
        {
            //Loads data
            pd = SaveManager.Load();
        }

        
        ///MOVED TO CONTINUEBUTTON SCRIPT
        ///WILL DELETE SOON
        ///IF I REMEMBER!
        //public void ContinueLastSave()
        //{
        //    if (!string.IsNullOrWhiteSpace(pd.CurrentLevel))
        //    {
        //        //Loads data (Again just in case)
        //        pd = SaveManager.Load();

        //        try
        //        {
        //            //References the PlayerData for the current level
        //            SceneToLoad = pd.CurrentLevel;

        //            //Loads the current level when called
        //            ChangeScene(SceneToLoad);
        //        }
        //        catch (NullReferenceException nullError)
        //        {
        //            Debug.Log("Null Error. Check pd.Current Level.");
        //            Debug.LogError("Not Loaded" + nullError.ToString());
        //        }

        //    }
        //    else 
        //    {
        //        Debug.Log("pd.CurrentLevel is Null / White Space");
        //    }
        //}

        public void ChangeScene(string SceneToLoad)
        {
            //Changes scene to the specified scene
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}