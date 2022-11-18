using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : Enemy
{
    enum CultistState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,    
    }

    CultistState cultistState = CultistState.Idle;
    float waitTimer = 0f;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }


    protected override void Update()
    {

        switch (cultistState)
        {
            case CultistState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    cultistState = CultistState.Chasing;
                }
                //if (isHit == true)
                //{
                //    cultistState = CultistState.Hit;
                //}
                break;
            case CultistState.Chasing:
                base.Update();
                //float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                //if (distance <= 1f)
                //{
                //    //cultistState = CultistState.Attacking;
                //}
                break;
            //case CultistState.Attacking:
            //    base.Update();
            //    animator.SetBool("isWalking", false);
            //    animator.SetTrigger("Attack");
            //    cultistState = CultistState.Idle;
            //    waitTimer = 0f;
            //    break;
            //case CultistState.Hit:
            //    animator.SetTrigger("Hit");
            //    //isHit = false;
            //    cultistState=CultistState.Idle;
            //    break;
                
            default:
                break;
        }
    }
}
