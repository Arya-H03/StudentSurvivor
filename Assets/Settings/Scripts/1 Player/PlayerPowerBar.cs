using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 1.25f, 0);

            float flameRatio = (float)player.playerFlame / player.playerMaxFlame;
            foreground.transform.localScale = new Vector3(flameRatio, 1, 1);
        }

    }
}
