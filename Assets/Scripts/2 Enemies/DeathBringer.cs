using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringer : Enemy
{
    enum DeathBringerState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    DeathBringerState deathBringerState = DeathBringerState.Idle;
    float waitTimer = 0f;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }


    protected override void Update()
    {

        switch (deathBringerState)
        {
            case DeathBringerState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    deathBringerState = DeathBringerState.Chasing;
                }
                
                break;
            case DeathBringerState.Chasing:
                base.Update();
                //float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                //if (distance >= 3f)
                {
                    //deathBringerState = DeathBringerState.Attacking;
                }
                break;
            //case DeathBringerState.Attacking:
            //    base.Update();
            //    animator.SetBool("isWalking", false);
            //    animator.SetTrigger("Attack");
            //    deathBringerState = DeathBringerState.Idle;
            //    waitTimer = 0f;
            //    break;
           
            default:
                break;
        }
    }
}
