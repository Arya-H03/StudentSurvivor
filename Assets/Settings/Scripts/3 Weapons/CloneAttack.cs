using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneAttack : BaseWeapon
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    GameObject enemy;
    GameObject player;

    



    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(CloneSpawnCoroutine());


    }

    IEnumerator CloneSpawnCoroutine()
    {


        while (true)
        {

            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(2);

            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
            //yield return new WaitForSeconds(1f);

        }








    }

    void Update()
    {
        
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        
       
        player = GameObject.FindGameObjectWithTag("Player");


        if (enemy != null)
        {
            //Vector3 destination = player.transform.position;
            //Vector3 source = enemy.transform.position;

            ////var dx = source.x - destination.x;
            ////var dy = source.y - destination.y;




            //if (Mathf.Abs(dx) <= 10 && Mathf.Abs(dy) <= 10)
            //{
            //transform.position = enemy.transform.position;
            //}
            Vector3 destination = enemy.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            int scaleX = 1;


            direction.Normalize();
            transform.position = direction * Time.deltaTime * 3;



            if (direction.x < 0)
            {
                scaleX = -1;
            }
            transform.localScale = new Vector3(scaleX, 1, 1);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(damage);
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
        }
    }

    
}
