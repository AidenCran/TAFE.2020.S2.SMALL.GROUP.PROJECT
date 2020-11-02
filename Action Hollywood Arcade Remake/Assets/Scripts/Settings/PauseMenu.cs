using AidensWork;
using Hoey.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Aiden Cran
/// Date: 14/10/2020
/// Last Edited: 
/// 
/// Handles opening the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{

    #region ---[ singleton code base ]---

    // Singleton Reference
    private static PauseMenu _instance;
    public static PauseMenu Instance { get { return _instance; } }

    // Setup Variables
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public GameObject PlayerCharacterRef;

    public GameObject TimerScriptRef;

    public GameObject PauseMenuRef;

    public GameObject ScoreTextRef;

    public GameObject HUDClutter;

    public GameObject ScriptHolderRef;

    public bool GamePaused;

    /// <summary>
    /// This function is called when "Escape" is pressed
    /// It determines if the menu is open, if it's not, pressing esc opens the menu.
    /// Else it closes the menu
    /// </summary>
    public void TogglePlayerMenu()
    {
        //Prevents the player from opening the menu if the game is over
        if (ScriptHolderRef.GetComponent<GameOverCondition>().GameOver == false)
        { 
            if (GamePaused == false)
            {
                PauseMenuRef.SetActive(true);
                ScoreTextRef.SetActive(false);
                PauseGame(true);
            }
            else
            {
                PauseMenuRef.SetActive(false);
                ScoreTextRef.SetActive(true);
                PauseGame(false);
            }
        }
    }

    public void PauseGame(bool ToggleOnOff)
    {
        //Disables Player Movement
        PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = !ToggleOnOff;

        //Disables Game Time
        //Invert the bool toggle to disable time
        TimerScriptRef.GetComponent<GameTime>().enabled = !ToggleOnOff;

        //Deactivates unnecessary UI
        HUDClutter.SetActive(!ToggleOnOff);

        ScriptHolderRef.GetComponent<LensBlur>().EnableBlur(ToggleOnOff);

        GamePaused = ToggleOnOff;
    }
}
