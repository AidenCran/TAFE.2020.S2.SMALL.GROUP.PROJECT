using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AidensWork;

namespace AidensWork
{
    public class GameNavigation : MonoBehaviour
    {
        public void ChangeScene(string SceneToLoad)
        {
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}