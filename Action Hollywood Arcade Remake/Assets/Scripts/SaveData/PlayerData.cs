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
    public string playerName;
    public int playerScore;
}