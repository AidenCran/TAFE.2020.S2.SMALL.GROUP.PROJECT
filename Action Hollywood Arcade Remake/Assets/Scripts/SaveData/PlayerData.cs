[System.Serializable]


/// <summary>
/// Author*: Aiden Cran 
/// Date: 8/10/2020
/// 
/// This script stores the basic data that will be saved
/// This saving method isn't protected against the user, so only basic details are stored in it.
/// 
/// I followed Comp-3's Video on Saving Data
/// https://www.youtube.com/watch?v=aV2OA4f5ru8
/// </summary>

public class PlayerData
{
    //Place the player data here. 
    //This data is accessable anywhere through directly referencing the PlayerData script.
    
    //PlayerName is literally "Null" to check if the player actually wrote anything.
    public string playerName = "";
    public int playerScore;

    //References which level the player left off on.
    public string CurrentLevel;
    //Current Level Index. 
    //Defaults to 0. This is checked in the SetCurrentLevel script.
    public int CurrentLevelIndex = 0;

    ///THIS MUST BE UPDATED IF THE BUILD STRUCTURE CHANGES
    ///THIS VARIABLE WONT BE CHANGED OTHERWISE
    public int LevelOneSceneIndex = 5;

    //Keeps track of the highest level the player has gotten to.
    //Default is 5. It is 5 because the index of scene 1 is 5.
    //Refer to Docs or SetCurrentLevel.cs / StageSelection for more.
    public int HighestLevelAchieved;

}