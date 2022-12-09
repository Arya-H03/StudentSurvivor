using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button level1Button;
    [SerializeField] Button level2Button;
    [SerializeField] Image[] levelImage;
    // Start is called before the first frame update
    void Start()
    {
        level1Button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(TitleManager.saveData.isLevel2Unlocked == true)
        {
            levelImage[0].color = Color.white;  
        }

        if (TitleManager.saveData.isLevel2Unlocked == false)
        {
            levelImage[0].color = Color.black;
        }
    }
    public void OnLevel2Click()
    {
        if (TitleManager.saveData.isLevel2Unlocked == true)
        {
            TitleManager.CurrentLevel = "Level2";
            level2Button.interactable = false;
            level1Button.interactable = true;
        }
    }
    public void OnLevel1Click()
    {
        
            TitleManager.CurrentLevel = "Level1";
            level1Button.interactable = false;
            level2Button.interactable = true;
        
    }
}
