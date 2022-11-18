using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
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
        StartCoroutine(EnergyBallCoroutine());

        
        
    }

    IEnumerator EnergyBallCoroutine()
    {
        

        
            circleCollider.enabled = true;
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(2f);


            circleCollider.enabled = false;
            spriteRenderer.enabled = false;
            
        

    }

    // Update is called once per frame
    void Update()
    {


        //float scaleX;

        //scaleX = -player.transform.localScale.x;

        if (enemy != null)
        {
            Vector3 destination = enemy.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += direction *Time.deltaTime * 3f;
        }

        else if(enemy  == null)
        {

            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.Damage(2);
            Destroy(gameObject);
        }
        
        
    }
}
