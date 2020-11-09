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
    /// Start Function for Score Objects
    /// </summary>
    public class OnScoreSpawn : MonoBehaviour
    {
        private float IFrameDuration = 0.5f;
        private string CurrentTag;

        private void Start()
        {
            CurrentTag = this.gameObject.tag;

            StartCoroutine(ScoreIFrame());
        }

        private IEnumerator ScoreIFrame()
        {
            this.gameObject.tag = "Invincible";

            yield return new WaitForSeconds(IFrameDuration);

            this.gameObject.tag = CurrentTag;
        }
    }
}
