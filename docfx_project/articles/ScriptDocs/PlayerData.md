PlayerData Script
=================

The Player Data script holds all the variables that will be saved into the text file.

If you want to modify one of these variables, you simply reference it with the filename. This file is not appart of monobehaviour, so you cannot directly reference it by pulling it into the scene.

## PlayerData code

    [System.Serializable]

    public class PlayerData
    {
        //Place the player data here. 
        //This data is accessable anywhere through directly referencing the PlayerData script.
        public string playerName;
        public int playerScore;

        //References which level the player left off on.
        public string CurrentLevel;

        //Keeps track of the highest level the player has gotten to.
        public int HighestLevelAchieved;
    }

That's it. This file's only purpose is for holding the data between storing and loading it.

To do this however, we require the use of '' [System.Serializable] '' 
