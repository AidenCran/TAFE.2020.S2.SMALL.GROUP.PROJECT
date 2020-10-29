using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 14/10/2020
    /// Last Edited: 
    /// 
    /// Allows the user to change resolution, defaults to 1080p 60fps, fullscreen.
    /// </summary>
    public class ChangeResolution : MonoBehaviour
    {

        public bool isFullscreen = true;

        void Start()
        {
            //Defaults the resolution at 1080p, fullscreen, 60HZ
            Screen.SetResolution(1920, 1080, true, 60);
        }

        public void SetResolution1080p()
        {
            //Switch to 1080p, 60hz
            Screen.SetResolution(1920, 1080, isFullscreen, 60);
        }
        public void SetResolutionWindowed720p()
        {
            //Switch to 720p, 60hz
            Screen.SetResolution(1280, 720, isFullscreen, 60);
        }

        public TextMeshProUGUI SettingsDropdown;
        public void DropDownHandler(int val)
        {
            if (val == 0)
            {
                SetResolution1080p();
            }

            if (val == 1)
            {
                SetResolutionWindowed720p();
            }

            if (val == 2)
            {
                //SetResolutionWindowed360p();
            }
        }
    }
}
