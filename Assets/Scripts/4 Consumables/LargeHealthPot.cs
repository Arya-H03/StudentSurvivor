using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeHealthPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();



        if (player)
        {

            player.AddHP(player.playerMaxHP / 2);
            Destroy(gameObject);

        }


    }
}
