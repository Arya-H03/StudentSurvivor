using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterManager : MonoBehaviour
{
    public static bool isRanger = false;
    public static bool isKnight = true;
    public static bool isWitch = false;
    [SerializeField]  Button rangerButton;
    [SerializeField]  Button knightButton;
    [SerializeField]  Button witchButton;


    // Start is called before the first frame update
    void Start()
    {
        knightButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickChooseRanger()
    {
        isRanger = true;
        isKnight = false;
        isWitch = false;    
        rangerButton.interactable = false;
        knightButton.interactable = true;
        witchButton.interactable = true;

    }

    public void OnClickChooseKnight()
    {
        isKnight = true;
        isRanger = false;
        isWitch = false;
        knightButton.interactable = false;
        rangerButton.interactable = true;
        witchButton.interactable = true;

    }

    public void OnClickChooseWitch()
    {
        isWitch = true;
        isRanger = false;
        isKnight = false;
        witchButton.interactable = false;
        knightButton.interactable = true;
        rangerButton.interactable = true;

    }

}

