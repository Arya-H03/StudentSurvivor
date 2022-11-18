using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Magnet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();



        if (player)
        {



            Destroy(gameObject);



        }


    }

   


}
