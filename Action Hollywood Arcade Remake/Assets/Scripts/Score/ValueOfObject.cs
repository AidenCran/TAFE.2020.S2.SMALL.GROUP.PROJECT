using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date: 20/10/2020
    /// Last Edited:
    /// 
    /// Simple way of determining how much each score object is worth.
    /// Apply this script to a object prefab and define the value of that item.
    /// If this is a time object it will add time, if its a score object it will add score.
    /// Object type defined by tag.
    /// </summary>
    public class ValueOfObject : MonoBehaviour
    {
        public int ValueOfThisObject;
    }
}
