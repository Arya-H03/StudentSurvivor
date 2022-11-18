using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerArrow : MonoBehaviour
{
    [SerializeField] int arrowHp = 1;
    [SerializeField] float damage = 1;
    int numberOfPoisonTicks = 3;
    float poisonDotDamage = 0.5f;
    public bool isPoisonArrow = false;

    int a = 0;
    float directionX = 0;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (player != null)
        //{
        //    float scaleX;
        //    scaleX = player.transform.localScale.x;
        //    if (a < 1)
        //    {
        //        a = 1;
        //        directionX = -scaleX;
        //    }

        //    transform.position += new Vector3(directionX, 1, 0) * Time.deltaTime * 10f;
        //    transform.localScale = new Vector3(directionX, 1, 1);

        //}


        //else
        //{
        //    Destroy(gameObject);
        //}
        //transform.rotation = Quaternion.Euler(0, 0, -45);

        ArrowMovement(45f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
           
            enemy.Damage(damage);
            if (isPoisonArrow == true)
            {
                enemy.StartCoroutine(enemy.Poison(numberOfPoisonTicks, poisonDotDamage));
            }
            arrowHp--;
            if (arrowHp <= 0)
            {
                Destroy(gameObject);
            }

        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
            arrowHp--;
            if (arrowHp <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

    public void PoisonArrow()
    {
        isPoisonArrow = true;
        numberOfPoisonTicks++;
        poisonDotDamage = poisonDotDamage + 1;
    }

    public void Pierce()
    {
        arrowHp++;
    }

    public void IncreaseDamage(float buff)
    {
        damage = damage + buff;
    }

    public void ArrowMovement(float SpawnAngel)
    {

        if (player != null)
        {
            float scaleX;
            scaleX = player.transform.localScale.x;
            if (a < 1)
            {
                a = 1;
                directionX = -scaleX;
            }
            double radY = SpawnAngel * (180 / Math.PI);
            float directionY = (float)Math.Tan(radY) * directionX;
            Debug.Log(directionY);
            Debug.Log(directionX);

            transform.position += new Vector3(directionX, 0, 0) * Time.deltaTime * 10f;
            transform.localScale = new Vector3(directionX, 1, 1);

        }


        else
        {
            Destroy(gameObject);
        }


    }

}
