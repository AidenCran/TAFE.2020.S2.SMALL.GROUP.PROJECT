using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 9/10/2020
    /// 
    /// Place onto script holder with the WinLoseFunctions script.
    /// Space = Win
    /// Enter = Lose
    /// </summary>
    public class WinLoseTest : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<WinLoseFunctions>().WinFunction();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.GetComponent<WinLoseFunctions>().LoseFunction();
            }
        }
    }
}
