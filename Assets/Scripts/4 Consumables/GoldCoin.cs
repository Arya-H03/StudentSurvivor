using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    GameObject player;
     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        GoldlGoToPlayer(Player.isGoldPotion);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Crow crow = collision.GetComponent<Crow>();




        if (player)
        {

            TitleManager.saveData.goldCoins++;
            AfterDeath.goldGained++;
            Destroy(gameObject);
            

        }

        if (crow)
        {

            TitleManager.saveData.goldCoins++;
            AfterDeath.goldGained++;
            Destroy(gameObject);



        }




    }

    public void GoldlGoToPlayer(bool isGoldPotion)
    {

        if (isGoldPotion == true)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction;


            direction = destination - source;

            var dx = source.x - destination.x;
            var dy = source.y - destination.y;

            direction.Normalize();


            if (Mathf.Abs(dx) <= 50 && Mathf.Abs(dy) <= 50)
            {
                transform.position += direction * Time.deltaTime * 10;
            }
        }

    }

}
