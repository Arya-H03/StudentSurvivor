using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static SaveData saveData;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject heroMenu;
    [SerializeField] Axe axe;
    [SerializeField] TMP_Text playerGold;
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
        SceneManager.LoadScene("Game");
    }
    public void onUpgradeButtonClick()
    {
        upgradeMenu.SetActive(true);
    }

    public void onHeroButtonClick()
    {
        heroMenu.SetActive(true);
    }
    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void Axe()
    {
        
        if (TitleManager.saveData.goldCoins >= 100)
        {
            
            TitleManager.saveData.isAxeUpgradeActive = true;
          
          
           
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 100;




        }

    }

    public void GoldPotion()
    {
        
       
        if (TitleManager.saveData.goldCoins >= 200)
        {
            
            TitleManager.saveData.isGoldPotionActive = true;
            


            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 200;


        }

    }

    public void GiveGold()
    {
        TitleManager.saveData.isGoldPotionActive = false;
        TitleManager.saveData.isAxeUpgradeActive = false;
        TitleManager.saveData.goldCoins = 500;
       



    }

    public void ResetGold()
    {
        
        TitleManager.saveData.goldCoins = 0;




    }




    public void OnClickButtonReurnHome()
    {
        upgradeMenu.SetActive(false);
        heroMenu.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerGold.text = "Your coin: " + TitleManager.saveData.goldCoins.ToString();
    }

}
