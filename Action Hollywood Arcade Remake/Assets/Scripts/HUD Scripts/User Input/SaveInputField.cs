using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInputField : MonoBehaviour
{
    public GameObject ParentReference;
    //Allows us to reference the player's data, e.g. Name
    [SerializeField] PlayerData pd;
    public Text playerNameText;

    private void Update()
    {
        Debug.Log(playerNameText.text);
        pd.playerName = playerNameText.text;
    }


    public void SetName()
    {
         pd.playerName = playerNameText.text;
    }

    public void hide()
    {
        ParentReference.SetActive(false);
    }
    public void show()
    {
        ParentReference.SetActive(true);
    }
}
