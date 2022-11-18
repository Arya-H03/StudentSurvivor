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
    float direction = 0;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float scaleX;
            scaleX = player.transform.localScale.x;
            if (a < 1)
            {
                a = 1;
                direction = -scaleX;
            }

            transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * 10f;
            transform.localScale = new Vector3(direction, 1, 1);
            
        }

        else
        {
            Destroy(gameObject);
        }

        
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



}
