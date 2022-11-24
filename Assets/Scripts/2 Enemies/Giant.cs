using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : Enemy
{
    //private Animator animator;
    [SerializeField] GameObject dagger;

    //public bool isHit = false;
    enum GiantState
    {
        Idle = 0,
        Chasing = 1,
        Attacking= 2
    }

    GiantState giantState = GiantState.Idle;
    float waitTimer = 1f;
   
    protected override void Start()
    {
        animator = GetComponent<Animator>();   
        base.Start();
    }

   
    protected override void Update()
    {
       
        if(isHit == true)
        {
            giantState = GiantState.Idle;
            animator.SetBool("isWalking", false);
            waitTimer = 1f;
            isHit = false;
        }

        //if(enemyHP <= enemyMaxHP * 0.5) 
        //{
        //    isHit = false;
        //    giantState = GiantState.Attacking;
        //}

        switch (giantState)
        {
           case GiantState.Idle:
                waitTimer -= Time.deltaTime;  
                if(waitTimer <= 0)
                {
                    giantState = GiantState.Chasing;
                }
                break;
            case GiantState.Chasing:
                base.Update();
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                animator.SetBool("isWalking", true);
                if(distance <= 4f)
                {
                    giantState=GiantState.Attacking;
                }
                break;
            case GiantState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                if (isHit == true)
                {
                    giantState = GiantState.Idle;
                    animator.SetBool("isWalking", false);
                    waitTimer = 1f;
                    isHit = false;
                }
                giantState = GiantState.Idle;
                
                waitTimer = 3f;
                break;
            default:
                break;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            isHit = true;

        }

        BaseWeapon baseWeapon = collision.gameObject.GetComponent<BaseWeapon>();
        if (baseWeapon != null)
        {
            isHit = true;
        }
    } 
    public void SpawnKnife()
    {
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double angle = ConvertRadiansToDegrees(Math.Atan2(valueY, valueX));

        Instantiate(dagger, transform.position, Quaternion.Euler(0, 0, (float)angle + 180));
    }

    public static double ConvertRadiansToDegrees(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }

    protected override void KillEnemy()
    {
        base.KillEnemy();
        if (enemyHP <= 0)
        {

            AfterDeath.giantKilled++;
        }
    }
}
