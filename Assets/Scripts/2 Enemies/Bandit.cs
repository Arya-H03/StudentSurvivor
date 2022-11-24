using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    enum BanditState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    BanditState banditState = BanditState.Idle;
    float waitTimer = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isHit == true)
        {
            banditState = BanditState.Hit;
            isHit = false;
        }

        switch (banditState)
        {
            case BanditState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    banditState = BanditState.Chasing;
                }

                break;
            case BanditState.Chasing:
                base.Update();
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                animator.SetBool("isWalking", true);
                if (distance <= 0.5f)
                {
                    banditState = BanditState.Attacking;
                }
                break;
            case BanditState.Attacking:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                banditState = BanditState.Idle;
                waitTimer = 1f;
                break;
            case BanditState.Hit:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Hit");
                banditState = BanditState.Idle;
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

            AfterDeath.banditKilled++;
        }
    }
}
