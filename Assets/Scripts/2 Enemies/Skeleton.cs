using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    enum SkeletonState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    SkeletonState skeletonState = SkeletonState.Idle;
    float waitTimer = 0f;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }


    protected override void Update()
    {
        
        
        switch (skeletonState)
        {
            case SkeletonState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    skeletonState = SkeletonState.Chasing;
                }
              
                break;
            case SkeletonState.Chasing:
                base.Update();
                //float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                //if (distance <= 2f)
                //{
                //    //skeletonState = SkeletonState.Attacking;
                //}
                break;
            //case SkeletonState.Attacking:
            //    float distance1 = Vector3.Distance(transform.position, player.transform.position);
            //    base.Update();
            //    animator.SetBool("isWalking", false);
            //    animator.SetTrigger("Attack");
            //    if(distance1 > 2f)
            //    {
            //        skeletonState = SkeletonState.Idle;
            //    }
              
            //    waitTimer = 0f;
                //break;
            

            default:
                break;
        }
    }

    protected override void KillEnemy()
    {
        base.KillEnemy();
        if (enemyHP <= 0)
        {

            AfterDeath.skeletonKilled++;
        }
    }
}
