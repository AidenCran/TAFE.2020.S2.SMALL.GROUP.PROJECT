using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;
using UnityEngine.UI;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script handles displaying player information - mostly once saved and loaded
    ///             It is intended to be subscribed to the events of the SavingAndLoadingExternalData class
    /// </summary>
    public class DisplayingSavedData : MonoBehaviour
    {
        [SerializeField] private Text currentPlayerNameTextbox;
        [SerializeField] private Text currentExperiencePointsTextbox;
        [SerializeField] private Text currentLevelOfPlayerTextbox;
        [SerializeField] private Text eventThatRanTextbox;

        /// <summary>
        /// Example of how you could load in individual variables from another class - more granular control
        /// </summary>
        /// <param name="savedData">Object containing SaveData values</param>
        public void UpdateDetails(SavingAndLoadingExternalData savedData)
        {  
            currentPlayerNameTextbox.text = "Player: " + savedData.GetCurrentPlayerName();
            currentExperiencePointsTextbox.text = "EXP: " + savedData.GetCurrentExperiencePoints();
            currentLevelOfPlayerTextbox.text = "Level: " + savedData.GetCurrentLevelOfPlayer();
            eventThatRanTextbox.text = "Event Message: " + savedData.GetLastEventDetails();
        }

        /// <summary>
        /// Example of how you could load in the whole SaveData class instead - a chunk of data
        /// </summary>
        /// <param name="savedData">Object containing SaveData object</param>
        public void UpdateDetailsWhole(SavingAndLoadingExternalData savedData)
        {
            SaveData wholeDataLoaded = savedData.GetSaveDataWhole();
            currentPlayerNameTextbox.text = "Player: " + wholeDataLoaded.playerName;
            currentExperiencePointsTextbox.text = "EXP: " + wholeDataLoaded.currentExperience;
            currentLevelOfPlayerTextbox.text = "Level: " + wholeDataLoaded.currentLevel;
            eventThatRanTextbox.text = "Event Message: " + savedData.GetLastEventDetails();
        }
    }
}