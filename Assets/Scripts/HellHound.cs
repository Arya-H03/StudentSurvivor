using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : Enemy
{
    enum HellHoundState
    {
        Idle = 0,
        Chasing = 1,
        Hit = 3,
    }

    HellHoundState hellHoundState = HellHoundState.Idle;
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
            hellHoundState = HellHoundState.Hit;
            isHit = false;
        }

        switch (hellHoundState)
        {
            case HellHoundState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    hellHoundState = HellHoundState.Chasing;
                }
                
                break;
            case HellHoundState.Chasing:
                base.Update();
                animator.SetBool("isRunning", true);
                break;
            case HellHoundState.Hit:
                base.Update();
                animator.SetBool("isRunning", false);
                hellHoundState = HellHoundState.Idle;
                waitTimer = 0.5f;
                break;

            default:
                break;
        }
    }

    //protected override void KillEnemy()
    //{
    //    base.KillEnemy();
    //    if (enemyHP <= 0)
    //    {

    //        AfterDeath.cultistKilled++;
    //    }
    //}
}
