using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveKnightSpear : MonoBehaviour
{
    float speed = 6;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {

            player.OnDamageBoss(5);
            Destroy(gameObject);

        }


    }

    IEnumerator DestroyDagger()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
