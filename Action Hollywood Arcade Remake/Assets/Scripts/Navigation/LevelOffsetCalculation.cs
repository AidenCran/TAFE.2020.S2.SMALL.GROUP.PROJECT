//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using AidensWork;

//namespace AidensWork
//{
//    /// <summary>
//    /// Author: Aiden Cran
//    /// Date:
//    /// 
//    /// 
//    /// </summary>
//    public class LevelOffsetCalculation : MonoBehaviour
//    {
//        #region ---[ singleton code base ]---

//        // Singleton Reference
//        private static LevelOffsetCalculation _instance;
//        public static LevelOffsetCalculation Instance { get { return _instance; } }

//        // Setup Variables
//        private void Awake()
//        {
//            if (_instance != null && _instance != this)
//            {
//                Destroy(this.gameObject);
//            }
//            else
//            {
//                _instance = this;
//            }
//        }

//        #endregion

//        //States how many scenes are not "Level" scenes
//        //This is used in the start function to check if the current level is higher or lower than to highest achieved
//        public int SceneIndexOffset;

//        //Used to prevent the offset calculation from executing more than once
//        bool CalculateOffset;

//        public void start()
//        {
//            //if (CalculateOffset == false)
//            //{
//                //Checks what the index for the first level is
//                FirstLevelIndexOffset();
//                CalculateOffset = true;
//            //}
//        }

//        /// <summary>
//        /// This calculates how many Scenes there are in the build and subtracts the current position of Level 1 from the total
//        /// With this offset value, I can automatically account for adding more scenes without messing up the math
//        /// This math is used to calculate the highest achieved Level
//        /// </summary>
//        public void FirstLevelIndexOffset()
//        {
//            int LevelOneSceneIndex;
//            LevelOneSceneIndex = SceneManager.GetSceneByName("Level 1").buildIndex;

//            int TotalScenes;
//            TotalScenes = SceneManager.sceneCountInBuildSettings;

//            SceneIndexOffset = TotalScenes - LevelOneSceneIndex;
//        }
//    }
//}
