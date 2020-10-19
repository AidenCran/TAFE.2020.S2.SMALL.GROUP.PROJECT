using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// 
    /// </summary>
    public class StartMenuAnim : MonoBehaviour
    {
        public Animator StartAnimation;

        private void Start()
        {
            StartAnimation = gameObject.GetComponent<Animator>();

            //Plays Start Animation
            StartAnimation.SetTrigger("doStartMenuAni");
        }
    }
}
