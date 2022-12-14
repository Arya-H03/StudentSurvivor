using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TitleManager : MonoBehaviour
{
    public static SaveData saveData;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject heroMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject settingMenu;
    [SerializeField] Axe axe;
    [SerializeField] TMP_Text playerGoldUpgrade;
    [SerializeField] TMP_Text playerGoldHero;
    [SerializeField] Button axeButton; 
    [SerializeField] Button crowButton;
    [SerializeField] Button postProcessingOnButton;
    [SerializeField] Button postProcessingOffButton;
    public static string CurrentLevel = "Level1";
   
    
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");

    private void Awake()
    {
        if (saveData == null)
            Load();
        else
        {
            Save();
        }

        

    }

    private void Start()
    {
        if(TitleManager.saveData.ispostProcessing == true)
        {
            postProcessingOnButton.interactable = false;
            postProcessingOffButton.interactable = true;
        }

        if (TitleManager.saveData.ispostProcessing == false)
        {
            postProcessingOnButton.interactable = true;
            postProcessingOffButton.interactable = false;
        }

    }
     
    void Save() 
    {
        FileStream file = null;
        try 
        { 
            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        } 
        catch (Exception e) 
        { Debug.Log(e); 
        } 
        finally
        { 
            if (file != null) 
                file.Close(); 
        } 
    }

    void Load() { 
        FileStream file = null;
        try
        { 
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        } 
        catch (Exception e)
        { 
            Debug.Log(e.Message); 
            saveData = new SaveData();
        } 
        finally 
        { if (file != null) 
                file.Close(); }
         }


    public void onStartButtonClick()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
    public void onUpgradeButtonClick()
    {
        upgradeMenu.SetActive(true);
    }

    public void onHeroButtonClick()
    {
        heroMenu.SetActive(true);
    }

    public void OnLevelButtonClick()
    {
        levelMenu.SetActive(true);
    }
    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void onSettingButtonClick()
    {
        settingMenu.SetActive(true);    
    }

    public void onPostProcessingOnButtonClick()
    {
        TitleManager.saveData.ispostProcessing = true;
        if(TitleManager.saveData.ispostProcessing == true)
        {
            postProcessingOnButton.interactable = false;
            postProcessingOffButton.interactable = true;
        }
        
    }

     public void onPostProcessingOffButtonClick()
     {
        TitleManager.saveData.ispostProcessing = false;
        if (TitleManager.saveData.ispostProcessing == false)
        {
            postProcessingOffButton.interactable = false;
            postProcessingOnButton.interactable = true;
        }
    }

   
    public void Axe()
    {
        
        if (TitleManager.saveData.goldCoins >= 100)
        {
            
            TitleManager.saveData.isAxeUpgradeActive = true;
          
          
           
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 100;
            axeButton.interactable = false;
            


        }
    }

    public void Crow()
    {
        
       
        if (TitleManager.saveData.goldCoins >= 200)
        {
            
            TitleManager.saveData.isCrowActive = true;
            


            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 200;
            crowButton.interactable = false;

        }

    }

    public void GiveGold()
    {
        TitleManager.saveData.isCrowActive = false;
        TitleManager.saveData.isAxeUpgradeActive = false;
        crowButton.interactable = true;
        axeButton.interactable = true;
        TitleManager.saveData.goldCoins = 1000;
        TitleManager.saveData.isLevel2Unlocked = true;
       
        


    }

    public void ResetGold()
    {
        
        TitleManager.saveData.goldCoins = 0;
        TitleManager.saveData.isRangerUnlocked = false;
        TitleManager.saveData.isWitchUnlocked = false;
        TitleManager.saveData.isCrowActive = false;
        TitleManager.saveData.isAxeUpgradeActive = false;
        TitleManager.saveData.isLevel2Unlocked = false;
        TitleManager.saveData.isLevel2Unlocked = false;




    }




    public void OnClickButtonReurnHome()
    {
        upgradeMenu.SetActive(false);
        heroMenu.SetActive(false);
        levelMenu.SetActive(false);
        settingMenu.SetActive(false);
    }
    


  
    // Update is called once per frame
    void Update()
    {
        playerGoldUpgrade.text = "Your coin: " + TitleManager.saveData.goldCoins.ToString();
        playerGoldHero.text = "Your coin: " + TitleManager.saveData.goldCoins.ToString();
    }

}
