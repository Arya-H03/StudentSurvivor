using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
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

        if (isHit == true)
        {
            cultistState = CultistState.Hit;
            isHit = false;
        }

        switch (cultistState)
        {
            case CultistState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    cultistState = CultistState.Chasing;
                }
                
                break;
            case CultistState.Chasing:
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance <= 1f)
                {
                    cultistState = CultistState.Attacking;
                }
                break;
            case CultistState.Attacking:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                cultistState = CultistState.Idle;
                waitTimer = 1f;
                break;
            case CultistState.Hit:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Hit");
                cultistState = CultistState.Idle;
                waitTimer = 0.5f;
                break;

            default:
                break;
        }
    }

    protected override void KillEnemy()
    {
        base.KillEnemy();
        if (enemyHP <= 0)
        {
            
            AfterDeath.cultistKilled++;
        }
    }
}
