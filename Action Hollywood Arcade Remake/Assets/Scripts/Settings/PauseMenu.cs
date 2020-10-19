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
    public GameObject PlayerCharacterRef;

    public GameObject TimerScriptRef;

    public GameObject PauseMenuRef;

    public void OpenPauseMenu()
    {
        PauseMenuRef.SetActive(true);

        PauseGame();
    }

    public void PauseGame()
    {
        //Disables Player Movement
        PlayerCharacterRef.GetComponent<SimpleGridMovement>().enabled = false;
        //Disables Game Time
        TimerScriptRef.GetComponent<GameTime>().enabled = false;
    }
}
