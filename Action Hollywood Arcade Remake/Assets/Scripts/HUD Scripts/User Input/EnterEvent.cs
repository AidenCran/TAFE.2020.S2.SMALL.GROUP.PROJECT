using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// Small Cheap Event to detect whether the player has pressed submit
    /// </summary>
    public class EnterEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent onEnterPress;

        private void Update()
        {
            if (Input.GetButtonDown("Submit"))
            {
                onEnterPress?.Invoke();
            }
        }
    }
}
