### Win: Next level

        /// <summary>
        /// Called on level completion -
        /// This function prevents the player increasing the current stage level, unless they complete the latest stage.
        /// E.g. They cannot finish level 1, 3 times to reach level 4.
        /// They must complete level 1, then 2, then 3, and finally 4.
        /// </summary>
        public void IncreaseHighestLevelOnWin()
        {
            //References the current scene's index #
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            //We reduce it by 3 to account for the non-level scenes
            //Ideally this shouldn't be reduced by 3, but by a calculation done with the current scenes etc.
            //However for now 3 is fine.
            CurrentSceneIndex -= 3;

            Debug.Log("IncreaseOnLevelWin Function Called");

            //Compares the current index to the highest current
            //If it is more than or equal to the highest, the player can continue
            //Else nothing happens
            if (CurrentSceneIndex >= pd.HighestLevelAchieved)
            {
                pd.HighestLevelAchieved += 1;

                //Saves the new data
                SaveManager.Save(pd);

                Debug.Log("Highest Level Increased By 1.");
                Debug.Log("New Highest Level = " + pd.HighestLevelAchieved);
            }
            else
            {
                Debug.Log("Highest Level Not Increased");
                Debug.Log("This Scene Index is " + CurrentSceneIndex);
                Debug.Log("Current Highest Level = " + pd.HighestLevelAchieved);
            }
        }
