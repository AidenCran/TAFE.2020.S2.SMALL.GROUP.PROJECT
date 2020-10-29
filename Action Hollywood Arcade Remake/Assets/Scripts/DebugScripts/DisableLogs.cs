using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 11/10/2020
    /// 
    /// This script disables all debug logs, unless its in the Unity Editor.
    /// This will stop unused calls and save resources.
    /// </summary>
    public class DisableLogs : MonoBehaviour
    {
        private void Awake()
        {
            #if UNITY_EDITOR
                Debug.unityLogger.logEnabled = true;
            #else
                Debug.unityLogger.logEnabled = false;
            #endif
        }
    }
}
