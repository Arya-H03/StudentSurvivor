using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDeath : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void onRetryButtonClick()
    {
        
        SceneManager.LoadScene("Game");
    }

    public void onMainMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
