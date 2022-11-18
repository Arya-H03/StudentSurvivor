using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();



        if (player)
        {

            player.AddHP(player.playerMaxHP / 4);
            Destroy(gameObject);

        }


    }
}
