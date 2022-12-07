using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDemon : Enemy
{
    [SerializeField] GameObject fireBreath;
    enum FlyingDemonState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Hit = 3,
    }

    FlyingDemonState flyingDemon = FlyingDemonState.Idle;
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
            flyingDemon = FlyingDemonState.Hit;
            isHit = false;
        }

        switch (flyingDemon)
        {
            case FlyingDemonState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    flyingDemon = FlyingDemonState.Chasing;
                }

                break;
            case FlyingDemonState.Chasing:
                base.Update();
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                if (distance <= 3f)
                {
                    flyingDemon = FlyingDemonState.Attacking;
                }
                break;
            case FlyingDemonState.Attacking:
                animator.SetTrigger("Attack");
                flyingDemon = FlyingDemonState.Idle;
                waitTimer = 2f;
                break;
            case FlyingDemonState.Hit:
                flyingDemon = FlyingDemonState.Idle;
                waitTimer = 0.5f;
                break;



            default:
                break;
        }
    }

    public void SpawnFireBreath()
    {
        if (player && this)
        {
            if (transform.localScale.x >= 0)
            {
                fireBreath.transform.localScale = new Vector3(1, 1, 1);
                Instantiate(fireBreath, transform.position + new Vector3(1.5f, 0, -1), Quaternion.identity);
                
            }
            if (transform.localScale.x < 0)
            {
                fireBreath.transform.localScale = new Vector3(-1, 1, 1);
                Instantiate(fireBreath, transform.position + new Vector3(-1.5f, 0, -1), Quaternion.identity);
                
            }
        }
    }

    //public static double ConvertRadiansToDegrees(double radians)
    //{
    //    return Mathf.Rad2Deg * radians;
    //}
    protected override void KillEnemy()
    {
        base.KillEnemy();
        if (enemyHP <= 0)
        {

            AfterDeath.flyingDemonKilled++;
        }
    }
}
