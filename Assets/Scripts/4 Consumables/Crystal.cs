using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Crystal : MonoBehaviour
{
    GameObject player;
   
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

        CrystalGoToPlayer(Player.isMagnetPotion);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        


        if (player)
        {            
            player.AddExp();              
            player.AddScore();           
            Destroy(gameObject);
           
        }
    }

    public void CrystalGoToPlayer(bool isMagentPotion)
    {

       if(isMagentPotion == true)
        {
            if(player != null)
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

    


}
