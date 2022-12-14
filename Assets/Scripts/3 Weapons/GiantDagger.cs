using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GiantDagger : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] float giantDaggerDamage = 2f;
    float speed = 4;
    GameObject player;
    private bool isDestinationSet = false;
    Vector3 destination;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyDagger());
        

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (isDestinationSet == false)
            {
                destination = player.transform.position;
                isDestinationSet = true;
            }
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += direction * Time.deltaTime * speed;

            if (transform.position == destination)
            {
                Destroy(gameObject, 1);
            }
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
              Player player = collision.gameObject.GetComponent<Player>();
       
        if (player != null)
        {

            player.OnDamage();
            Destroy(gameObject);

        }

       
    }

    IEnumerator DestroyDagger()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

   
}
