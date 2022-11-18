using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnergyBall : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        StartCoroutine(TrackingEnergyBallCoroutine());



    }

    IEnumerator TrackingEnergyBallCoroutine()
    {



        
        circleCollider.enabled = true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(10f);


        circleCollider.enabled = false;
        spriteRenderer.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {


        //float scaleX;

        //scaleX = -player.transform.localScale.x;

            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += direction * Time.deltaTime * 3f;
       

        if (player == null)
        {

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.playerHP = player.playerHP - damage;
            
        }


    }
}
