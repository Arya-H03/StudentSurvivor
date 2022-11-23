using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDeath : MonoBehaviour
{
    [SerializeField] GameObject RunInfoMenu; 
    [SerializeField] TMP_Text gold; 
    [SerializeField] TMP_Text EXP; 
    [SerializeField] TMP_Text cultist; 
    [SerializeField] TMP_Text skeleton; 
    [SerializeField] TMP_Text slime; 
    [SerializeField] TMP_Text giant; 
    [SerializeField] TMP_Text nightBorne; 

    public static int goldGained;
    public static int EXPgained;
    public static int cultistKilled;
    public static int skeletonKilled;
    public static int slimeKilled;
    public static int giantKilled;
    public static int nightBorneKilled;
   
    // Start is called before the first frame update
    public void onRetryButtonClick()
    {        
        SceneManager.LoadScene("CastleLevel");
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
        RunInfoMenu.SetActive(false);
    }

    public void OnClickButtonShowRunInfo()
    {
        RunInfoMenu.SetActive(true);
       
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
    }

    private void SetRunInfo()
    {
        EXP.text = EXPgained.ToString();
        gold.text = goldGained.ToString();
        cultist.text = cultistKilled.ToString();
        skeleton.text = skeletonKilled.ToString();
        slime.text = slimeKilled.ToString();
        giant.text = giantKilled.ToString();
        nightBorne.text = nightBorneKilled.ToString();
    }
}
