using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
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
    [SerializeField] Image[] characterSelectionImage;
    

    // Start is called before the first frame update
    void Start()
    {
        knightButton.interactable = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleManager.saveData.isRangerUnlocked == true)
        {
            characterSelectionImage[0].color = Color.white;
        }
        else characterSelectionImage[0].color = Color.black;

        if (TitleManager.saveData.isWitchUnlocked == true)
        {
            characterSelectionImage[1].color = Color.white;
        }
        else characterSelectionImage[1].color = Color.black;
    }

    public void OnClickChooseRanger()
    {
        if (TitleManager.saveData.goldCoins >= 200 && TitleManager.saveData.isRangerUnlocked == false)
        {
            TitleManager.saveData.isRangerUnlocked = true;
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 200;
            
        }

        if(TitleManager.saveData.isRangerUnlocked == true)
        {
            isRanger = true;
            isKnight = false;
            isWitch = false;
            rangerButton.interactable = false;
            knightButton.interactable = true;
            witchButton.interactable = true;
        }

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

        if (TitleManager.saveData.goldCoins >= 200 && TitleManager.saveData.isWitchUnlocked == false)
        {   
            TitleManager.saveData.isWitchUnlocked = true;
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 200;
            
        }

        if (TitleManager.saveData.isWitchUnlocked == true)
        {
            isWitch = true;
            isRanger = false;
            isKnight = false;
            witchButton.interactable = false;
            knightButton.interactable = true;
            rangerButton.interactable = true;
        }
    }

}

