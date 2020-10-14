using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Events;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script does...
    /// Modified from: https://www.raywenderlich.com/418-how-to-save-and-load-a-game-in-unity#:~:text=There%20are%20four%20key%20concepts%20to%20saving%20in,but%20it%20is%20bad%20practice%20to%20do%20so.
    /// Modified from: https://phyinteractive.com/learn/unity/json/exporting-json-data
    /// Want persistant objects (like enemies or spawned items)?  Check out this too: https://catlikecoding.com/unity/tutorials/object-management/persisting-objects/
    /// </summary>
    public class SavingAndLoadingExternalData : MonoBehaviour
    {
        [SerializeField] int currentExperiencePoints;
        [SerializeField] int currentLevelOfPlayer;

        [ContextMenuItem("Get a random name", "RandomName")]
        [SerializeField] string currentPlayerName;

        
        [ContextMenuItem("Get a random name", "RandomData")]
        [SerializeField] private SaveData savedDetails;

        [SerializeField] UnityEvent OnSaveBinary;
        [SerializeField] UnityEvent OnLoadBinary;
        [SerializeField] UnityEvent OnSaveItemsBinary;
        [SerializeField] UnityEvent OnLoadItemsBinary;
        [SerializeField] UnityEvent OnSaveJSON;
        [SerializeField] UnityEvent OnLoadJSON;

       
        [SerializeField] string lastEventDetails;
        public int GetCurrentExperiencePoints() { return currentExperiencePoints; }
        public int GetCurrentLevelOfPlayer() { return currentLevelOfPlayer; }
        public string GetCurrentPlayerName() { return currentPlayerName; }

        public SaveData GetSaveDataWhole() { return savedDetails; }
        public string GetLastEventDetails() { return lastEventDetails; }

        public void RandomName()
        {
            List<string> namesToChooseFrom = new List<string> { "Barry", "Susan", "Jin", "Jason" };
            currentPlayerName = namesToChooseFrom[Random.Range(0, namesToChooseFrom.Count)];
        }

        [ContextMenu("Randomize the Data")]
        public void RandomData()
        {
            List<SaveData> dataToChooseFrom = new List<SaveData>
            {
                new SaveData("Thomas", 100, 30),
                new SaveData("Jack", 78, 87),
                new SaveData("Jill", 9, 90),
                new SaveData("Tafline", 67, 156)
            };
            savedDetails = dataToChooseFrom[Random.Range(0, dataToChooseFrom.Count)];
        }

        ////Keyboard input code for testing before using events
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        SaveGame();
        //        SaveGameAsJSON();
        //        StraightSave();
        //    }
        //    if (Input.GetKeyDown(KeyCode.L))
        //    {
        //        LoadGame();
        //        LoadGameAsJSON();
        //        StraightLoad();
        //    }
        //}

        #region Using the whole serialized object - saving and loading it in one go (easiest)
        /// <summary>
        /// Using the whole serialized object - saving it in one go
        /// </summary>
        /// <param name="saveFileName"></param>
        public void StraightSave(string saveFileName = "Hoey_SaveGame01.moo")
        {
            string saveFilepath = Path.Combine(Application.persistentDataPath, saveFileName);
            Debug.Log(saveFilepath);
            if (File.Exists(saveFilepath))
            {
                Debug.LogWarning($"Player data being overwritten at {saveFilepath}");
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(saveFilepath);
            bf.Serialize(file, savedDetails);
            file.Close();

            lastEventDetails = "Game data saved to Binary";
            OnSaveBinary?.Invoke();
        }

        /// <summary>
        /// Using the whole serialized object - loading it in one go 
        /// </summary>
        /// <param name="loadFileName"></param>
        public void StraightLoad(string loadFileName = "Hoey_SaveGame01.moo")
        {
            string loadFilepath = Path.Combine(Application.persistentDataPath, loadFileName);

            if (!File.Exists(loadFilepath))
            {
                Debug.LogError($"File not found: {loadFilepath}");
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(loadFilepath, FileMode.Open);
            savedDetails = (SaveData)bf.Deserialize(file);
            file.Close();

            lastEventDetails = "Game data loaded from Binary";
            OnLoadBinary?.Invoke();
        }
        #endregion


        #region Saving and Loading the data with a bit more control
        /// <summary>
        /// Saving items into the serialized object - user controlling how much to save
        /// </summary>
        /// <returns></returns>
        private SaveData CreateSaveGameObject()
        {
            SaveData saveInformation = new SaveData();
            saveInformation.currentExperience = currentExperiencePoints;
            saveInformation.currentLevel = currentLevelOfPlayer;
            saveInformation.playerName = currentPlayerName;

            //OR with a nice constructor
            //SaveData saveInformation2 = new SaveData(currentPlayerName, currentExperiencePoints, currentLevelOfPlayer);
            return saveInformation;
        }


        public void SaveGame(string saveFileName = "Hoey_SaveGame01.moo")
        {
            // 1 - Create a Save instance with all the data for the current session saved into it.
            SaveData saveInformation = CreateSaveGameObject();
            string saveFilepath = Path.Combine(Application.persistentDataPath, saveFileName);

            if (File.Exists(saveFilepath))
            {
                Debug.LogWarning($"Player data being overwritten at {saveFilepath}");
            }

            // 2 - Create a BinaryFormatter and a FileStream by passing a path for the Save instance to be saved to. It serializes the data (into bytes) and writes it to disk and closes the FileStream. There will now be a file named whatever you put into the loadFilePath variable e.g. "Hoey_SaveGame01.moo" on your computer. The filename and the .moo extension were just used as an example - you could use any filename and extension for the file save name.
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(saveFilepath);
            bf.Serialize(file, saveInformation);
            file.Close();

            // 3 - This just resets the game so that after the player saves, everything is in a default state.  You could omit this (like I have) if you wanted to keep playing and not change to another savegame, scene, or reset
           // currentExperiencePoints = 0;
           // currentLevelOfPlayer = 0;

            lastEventDetails = "Game variables saved to Binary";
            OnSaveItemsBinary?.Invoke();
            //Debug.Log("Game Saved");
        }

        public void LoadGame(string loadFileName = "Hoey_SaveGame01.moo")
        {
            // 1 - Checks to see that the save file exists. If it does, it updates the local values to match the stored values. Otherwise it logs to the console that there is no saved game.

            string loadFilepath = Path.Combine(Application.persistentDataPath, loadFileName);

            if (!File.Exists(loadFilepath))
            {
                Debug.LogError($"File not found: {loadFilepath}");
                return;
            }

            // 2 - Similar to what you did when saving the game, you again create a BinaryFormatter, only this time you are providing it with a stream of bytes to read instead of write. 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(loadFilepath, FileMode.Open);
            SaveData saveInformation = (SaveData)bf.Deserialize(file);
            file.Close();

            // 3 - Even though you have the save information, you still need to convert that into the local game state. This sets the local variables so that when the player continues playing they will exist locally. You could also update the UI to have the right information. 

            currentExperiencePoints = saveInformation.currentExperience;
            currentLevelOfPlayer = saveInformation.currentLevel;
            currentPlayerName = saveInformation.playerName;

            lastEventDetails = "Game variables loaded from Binary";
            OnLoadItemsBinary?.Invoke();
            //Debug.Log("Game Loaded");
        }


        public void SaveGameAsJSON(string saveFileName = "SaveGame01.json")
        {
            SaveData saveInformation = CreateSaveGameObject();
            string jsonOutput = JsonUtility.ToJson(saveInformation, prettyPrint: true);
            string saveFilepath = Path.Combine(Application.persistentDataPath, saveFileName);

            if (File.Exists(saveFilepath))
            {
                Debug.LogWarning($"Player data being overwritten at {saveFilepath}");
            }

            using (StreamWriter sw = new StreamWriter(saveFilepath))
            {
                sw.Write(jsonOutput);
            }

            lastEventDetails = "Game variables saved to JSON";
            OnSaveJSON?.Invoke();
            //Debug.Log("Saving as JSON: " + jsonOutput);
        }

        public void LoadGameAsJSON(string loadFileName = "SaveGame01.json")
        {
            string loadFilepath = Path.Combine(Application.persistentDataPath, loadFileName);

            if (!File.Exists(loadFilepath))
            {
                Debug.LogError($"File not found: {loadFilepath}");
                return;
            }

            string jsonData;
            using (StreamReader sr = new StreamReader(loadFilepath))
            {
                jsonData = sr.ReadToEnd();
            }

            SaveData saveInformation = JsonUtility.FromJson<SaveData>(jsonData);

            currentPlayerName = saveInformation.playerName;
            currentExperiencePoints = saveInformation.currentExperience;
            currentLevelOfPlayer = saveInformation.currentLevel;

            lastEventDetails = "Game variables loaded from JSON";
            OnLoadJSON?.Invoke();
            //Debug.Log("Loading as JSON: " + jsonData);
        }


        #endregion
    }
}