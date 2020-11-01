using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInputField : MonoBehaviour
{
    // Reference to objects
    public GameObject ParentReference;
    public GameObject StartButtonReference;

    // Allows us to reference the player's data, e.g. Name
    [SerializeField] PlayerData pd;
    public Text playerNameText;

    // Defines if menu is currently open
    public bool isMenuOpen;

    public void Start()
    {
        // On Start loads the data
        Load();
    }

    //public void SaveAndContinue()
    //{
    //    // Checks if menu is open before executing
    //    if (isMenuOpen == true)
    //    {
    //        SetName();
    //        Save();
    //        //hide();
    //    }
    //}

    public void SetName()
    {
         pd.playerName = playerNameText.text;
    }

    public void show()
    {
        ParentReference.SetActive(true);
        isMenuOpen = true;
    }

    public void hide()
    {
        ParentReference.SetActive(false);
        isMenuOpen = false;
    }

    public void Save()
    {
        SaveManager.Save(pd);
    }

    public void Load()
    {
        pd = SaveManager.Load();
    }
}
