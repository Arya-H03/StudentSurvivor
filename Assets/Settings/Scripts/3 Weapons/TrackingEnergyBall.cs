using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEnergyBall : BaseWeapon
{
    GameObject player;
    GameObject enemy;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    

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
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);




        circleCollider.enabled = false;
        spriteRenderer.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
       

        

        if (enemy != null)
        {
            Vector3 destination = enemy.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += direction * Time.deltaTime * 4f;
            if(destination.x - source.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }


        }

        
       
        

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
            Destroy(gameObject);
        }


    }
}
