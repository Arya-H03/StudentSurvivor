using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkull : MonoBehaviour
{
   float speed = 7;
    GameObject player;
    private bool isDestinationSet = false;
    Vector3 destination;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyFireSkull());
    }

    // Update is called once per frame
    void Update()
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.OnDamageBoss(5);
            Destroy(gameObject);
        }


    }

    IEnumerator DestroyFireSkull()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
