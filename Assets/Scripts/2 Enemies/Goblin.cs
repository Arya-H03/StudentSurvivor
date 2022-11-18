using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    GameObject goldCoin;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        goldCoin = GameObject.FindGameObjectWithTag("GoldCoin");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (goldCoin == null)
        {
            goldCoin = GameObject.FindGameObjectWithTag("GoldCoin");

            if (goldCoin == null)
            {
                Vector3 destination = player.transform.position + new Vector3(3, 3, 0); ;
                Vector3 source = transform.position;
                Vector3 direction = destination - source;
                int scaleX = 1;


                direction.Normalize();
                transform.position += direction * Time.deltaTime * 3;



                if (direction.x < 0)
                {
                    scaleX = -1;
                }
                transform.localScale = new Vector3(scaleX, 1, 1);
            }
        }

        if(goldCoin != null)
        {
            Vector3 destination = goldCoin.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            int scaleX = 1;


            direction.Normalize();
            transform.position += direction * Time.deltaTime * 3;



            if (direction.x < 0)
            {
                scaleX = -1;
            }
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
            


        

        
    }
}
