using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDeath : MonoBehaviour
{
    [SerializeField] GameObject RunInfoMenuLevel1; 
    [SerializeField] GameObject RunInfoMenuLevel2; 
    [SerializeField] TMP_Text gold1; 
    [SerializeField] TMP_Text gold2; 
    [SerializeField] TMP_Text EXP1; 
    [SerializeField] TMP_Text EXP2; 
    [SerializeField] TMP_Text cultist1; 
    [SerializeField] TMP_Text cultist2; 
    [SerializeField] TMP_Text skeleton1; 
    [SerializeField] TMP_Text skeleton2; 
    [SerializeField] TMP_Text slime; 
    [SerializeField] TMP_Text giant; 
    [SerializeField] TMP_Text nightBorne; 
    [SerializeField] TMP_Text bandit; 
    [SerializeField] TMP_Text fireWorm; 
    [SerializeField] TMP_Text flyingDemon; 
    [SerializeField] TMP_Text hellBeast; 
    [SerializeField] TMP_Text hellHound; 

    public static int goldGained;
    public static int EXPgained;
    public static int cultistKilled;
    public static int skeletonKilled;
    public static int slimeKilled;
    public static int giantKilled;
    public static int nightBorneKilled;
    public static int banditKilled;
    public static int fireWormKilled;
    public static int flyingDemonKilled;
    public static int hellBeastKilled;
    public static int hellHoundKilled;
   
   
    // Start is called before the first frame update
    public void onRetryButtonClick()
    {        
        SceneManager.LoadScene(TitleManager.CurrentLevel);
        RestRunInfo();
    }

    public void onMainMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
        RestRunInfo();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetRunInfo();
    }

    public void OnClickButtonHome()
    {
        if (TitleManager.CurrentLevel == "Level1")
        {
            RunInfoMenuLevel1.SetActive(false);
        }

        if (TitleManager.CurrentLevel == "Level2")
        {
            RunInfoMenuLevel2.SetActive(false);
        }

    }

    public void OnClickButtonShowRunInfo()
    {
        if(TitleManager.CurrentLevel == "Level1")
        {
            RunInfoMenuLevel1.SetActive(true);
        }

        if (TitleManager.CurrentLevel == "Level2")
        {
            RunInfoMenuLevel2.SetActive(true);
        }



    }

    private void RestRunInfo()
    {
        goldGained = 0;
        EXPgained = 0;
        cultistKilled = 0;
        skeletonKilled = 0;
        slimeKilled = 0;
        giantKilled = 0;
        nightBorneKilled = 0;
        banditKilled = 0;
        fireWormKilled =0;
        flyingDemonKilled=0;
        hellBeastKilled=0;
        hellHoundKilled=0;

}

    private void SetRunInfo()
    {
        EXP1.text = EXPgained.ToString();
        gold1.text = goldGained.ToString();
        cultist1.text = cultistKilled.ToString();
        skeleton1.text = skeletonKilled.ToString();
        EXP2.text = EXPgained.ToString();
        gold2.text = goldGained.ToString();
        cultist2.text = cultistKilled.ToString();
        skeleton2.text = skeletonKilled.ToString();
        slime.text = slimeKilled.ToString();
        giant.text = giantKilled.ToString();
        nightBorne.text = nightBorneKilled.ToString();
        bandit.text = banditKilled.ToString();
        fireWorm.text = fireWormKilled.ToString();
        flyingDemon.text = flyingDemonKilled.ToString();
        hellBeast.text =hellHoundKilled.ToString();
        hellHound.text =hellHoundKilled.ToString(); 

    }
}
