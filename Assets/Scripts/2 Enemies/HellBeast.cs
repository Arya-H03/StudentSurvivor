using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HellBeast : Enemy
{
    [SerializeField] GameObject fireBolt;
    enum HellBeastState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }
    
    HellBeastState hellBeastState = HellBeastState.Idle;
    float waitTimer = 1f;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }


    protected override void Update()
    {
        if (isHit == true)
        {
            hellBeastState = HellBeastState.Hit;
            isHit = false;
        }

        switch (hellBeastState)
        {
            case HellBeastState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    hellBeastState = HellBeastState.Chasing;
                }

                break;
            case HellBeastState.Chasing:
                base.Update();
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                if (distance <= 5f)
                {
                    hellBeastState = HellBeastState.Attacking;
                }
                break;
            case HellBeastState.Attacking:
                animator.SetTrigger("BreathFire");
                hellBeastState = HellBeastState.Idle;
                waitTimer = 1f;
                break;
            case HellBeastState.Hit:
                hellBeastState = HellBeastState.Idle;
                waitTimer = 0.5f;
                break;



            default:
                break;
        }
    }

    public void SpawnFireBolt()
    {
        if (player)
        {
            double valueX = player.transform.position.x - transform.position.x;
            double valueY = player.transform.position.y - transform.position.y;
            double angle = ConvertRadiansToDegrees(Math.Atan2(valueY, valueX));
            Instantiate(fireBolt, transform.position, Quaternion.Euler(0, 0, (float)angle ));
        }



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

            AfterDeath.hellBeastKilled++;
        }
    }
}
