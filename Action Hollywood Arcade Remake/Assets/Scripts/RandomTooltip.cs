using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 2/11/2020
    /// Last Edited:
    /// 
    /// Selects a random tooltip from an array
    /// </summary>
    public class RandomTooltip : MonoBehaviour
    {
        public GameObject[] ToolTips;

        private void Start()
        {
            StartCoroutine(ToolTipSelection());
        }

        private IEnumerator ToolTipSelection()
        {
            float WaitTime = 5f;

            for (int i = 0; i < ToolTips.Length; i++)
            {
                // Waits for # amount of time
                yield return new WaitForSeconds(WaitTime);

                // Sets Specific ToolTip Active
                ToolTips[i].SetActive(true);

                // Waits for # amount of time
                yield return new WaitForSeconds(WaitTime);

                // Deativates Specific ToolTip
                ToolTips[i].SetActive(false);
            }
            
            // Restarts the Selection again
            StartCoroutine(ToolTipSelection());
        }
    }
}
