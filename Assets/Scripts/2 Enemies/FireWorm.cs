using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorm : Enemy
{
    enum FireWormState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    FireWormState fireWormState = FireWormState.Idle;
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
            fireWormState = FireWormState.Hit;
            isHit = false;
        }

        switch (fireWormState)
        {
            case FireWormState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    fireWormState = FireWormState.Chasing;
                }

                break;
            case FireWormState.Chasing:
                base.Update();
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                animator.SetBool("isWalking", true);
                if (distance <= 0.5f)
                {
                    fireWormState = FireWormState.Attacking;
                }
                break;
            //case FireWormState.Attacking:
            //    base.Update();
            //    animator.SetBool("isWalking", false);
            //    animator.SetTrigger("Attack");
            //    fireWormState = FireWormState.Idle;
            //    waitTimer = 1f;
            //    break;
            case FireWormState.Hit:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Hit");
                fireWormState = FireWormState.Idle;
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

    //        AfterDeath.skeletonKilled++;
    //    }
    //}
}
