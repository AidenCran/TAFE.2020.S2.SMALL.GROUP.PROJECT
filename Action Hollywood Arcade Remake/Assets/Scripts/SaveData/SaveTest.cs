using UnityEngine;
using AidensWork;

/// <summary>
/// Author*: Aiden Cran 
/// Date: 8/10/2020
/// 
/// This script allows me to test Data saving & loading functions
/// This saving method isn't protected against the user, so only basic details are stored in it.
/// 
/// I followed Comp-3's Video on Saving Data
/// https://www.youtube.com/watch?v=aV2OA4f5ru8
/// </summary>
namespace AidensWork
{
    public class SaveTest : MonoBehaviour
    {
        //This exposes the PlayerData variables to us
        [SerializeField] PlayerData pd;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SaveManager.Save(pd);
                //Debug.Log("Data Saved");
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                pd = SaveManager.Load();
                //Debug.Log("Data Loaded");
            }
        }
    }
}