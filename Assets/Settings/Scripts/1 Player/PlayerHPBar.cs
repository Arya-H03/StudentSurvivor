using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] PlayerKnight playerKnight;
    [SerializeField] PlayerRanger playerRanger;
    [SerializeField] PlayerWitch playerWitch;
    [SerializeField] Image foreground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PlayerCharacterManager.isKnight == true)
        {
            if (playerKnight != null)
            {

                float hpRatio = (float)playerKnight.playerHP / playerKnight.playerMaxHP;
                foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            if (playerRanger != null)
            {

                float hpRatio = (float)playerRanger.playerHP / playerRanger.playerMaxHP;
                foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            if (playerWitch != null)
            {

                float hpRatio = (float)playerWitch.playerHP / playerWitch.playerMaxHP;
                foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
            }
        }
    }
}
