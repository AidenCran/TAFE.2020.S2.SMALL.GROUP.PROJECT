using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;

namespace Hoey.Examples
{
    /// <summary>
    /// Author: Mark Hoey
    /// Description: This script stores data. Notice it does not inherit from Monobehaviour and is Serializable

    /// Note: https://www.codeproject.com/articles/6037/nine-reasons-not-to-use-serialization
    ///  XML serialization only works on public methods and fields, and on classes with public constructors. That means your classes need to be accessible to the outside world. You cannot have private or internal classes, or serialize private data. In addition, it forces restrictions on how you implement collections.
    ///If you mark your classes as [Serializable], then all the private data not marked as [NonSerialized] will get dumped. You have no control over the format of this data.If you change the name of a private variable, then your code will break.
    ///You can get around this by implementing the ISerializable interface. This gives you much better control of how data is serialized and deserialized.
    
    /// </summary>

    //You need this attribute to show it in the Unity Editor, and also to write it to a binary file 
    [System.Serializable] 
    public class SaveData
    {
        public string playerName = "Generic";
        public int currentExperience = 0;
        public int currentLevel = 0;

        public SaveData()
        {

        }

        /// <summary>
        /// Public constructor if wanting to create class easier at instantiation
        /// </summary>
        /// <param name="inputPlayerName">supply the current player name</param>
        /// <param name="inputExperience">supply the current experience of the player</param>
        /// <param name="inputLevel">supply the current level of the player</param>
        public SaveData(string inputPlayerName, int inputExperience, int inputLevel)
        {
            playerName = inputPlayerName;
            currentExperience = inputExperience;
            currentLevel = inputLevel;
        }
    }
}  