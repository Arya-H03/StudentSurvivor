using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : Enemy
{
    enum NightBorneState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    NightBorneState nightBorneState = NightBorneState.Idle;
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
            nightBorneState = NightBorneState.Hit;
            isHit = false;
        }

        switch (nightBorneState)
        {
            case NightBorneState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    nightBorneState = NightBorneState.Chasing;
                }

                break;
            case NightBorneState.Chasing:
                base.Update();
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("isWalking", true);
                if (distance <= 0.5f)
                {
                    nightBorneState = NightBorneState.Attacking;
                }
                break;
            case NightBorneState.Attacking:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                nightBorneState = NightBorneState.Idle;
                waitTimer = 1f;
                break;
            case NightBorneState.Hit:
                base.Update();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Hit");
                nightBorneState = NightBorneState.Idle;
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

            AfterDeath.nightBorneKilled++;
        }
    }
}
