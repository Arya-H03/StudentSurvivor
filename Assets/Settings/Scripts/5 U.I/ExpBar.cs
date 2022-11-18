using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] PlayerKnight playerKnight;
    [SerializeField] PlayerRanger playerRanger;
    [SerializeField] PlayerWitch playerWitch;
    [SerializeField] Image foreground;
    void Start()
    {
        
    }
    private void Update()
    {
        if (PlayerCharacterManager.isKnight == true)
        {
            if (playerKnight != null)
            {
                float expRatio = (float)playerKnight.currentExp / playerKnight.expToLevel;
                foreground.transform.localScale = new Vector3(expRatio, 1, 1);
            }
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            if (playerRanger != null)
            {
                float expRatio = (float)playerRanger.currentExp / playerRanger.expToLevel;
                foreground.transform.localScale = new Vector3(expRatio, 1, 1);
            }
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            if (playerWitch != null)
            {
                float expRatio = (float)playerWitch.currentExp / playerWitch.expToLevel;
                foreground.transform.localScale = new Vector3(expRatio, 1, 1);
            }
        }


    }

}

