using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;
using UnityEngine.Rendering.PostProcessing;
using System;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// 
    /// </summary>
    public class LensBlur : MonoBehaviour
    {
        public GameObject SceneVolume;

        public void EnableBlur(bool ToggleOnOff)
        {
            SceneVolume.gameObject.SetActive(ToggleOnOff);
            //this.GetComponent<PostProcessVolume>().GetComponent<DepthOfField>().focusDistance.value = 1.8f;
        }
    }
}
