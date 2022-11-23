using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RaisedSkeleton : MonoBehaviour
{
    Animator animator;
    GameObject enemy;
    [SerializeField] float speed = 4;
    [SerializeField] public static int hp = 3;
    [SerializeField] public static int duration = 5;
    enum MobState
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2
    }

    MobState mobState = MobState.Idle;
    float waitTimer = 1f;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        animator = GetComponent<Animator>();
        StartCoroutine(DestroyObject());
    }


    void Update()
    {
        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
    
        switch (mobState)
        {
            case MobState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    mobState = MobState.Walking;
                }
                break;
            case MobState.Walking:

                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.unscaledDeltaTime);
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                Vector3 destination = enemy.transform.position;
                Vector3 source = transform.position;
                Vector3 direction = destination - source;
                int scaleX = 1;
                if (direction.x < 0)
                {
                    scaleX = -1;
                }
                transform.localScale = new Vector3(-scaleX, 1, 1);
                animator.SetBool("isWalking", true);
                if (distance <= 1.25f)
                {
                    mobState = MobState.Attacking;
                }
                break;
            case MobState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");               
                mobState = MobState.Idle;

                waitTimer = 1f;
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(enemy.enemyMaxHP);
            hp--;          

        }

        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (slaveKnight)
        {
            slaveKnight.DamageBoss(10);

        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

}
