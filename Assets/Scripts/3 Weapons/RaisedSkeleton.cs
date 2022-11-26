using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RaisedSkeleton : BaseWeapon
{
    Animator animator;
    [SerializeField] float speed = 4;
    [SerializeField] KnightSword skeletonMelee;
    [SerializeField] int hp = 3;
    [SerializeField] int duration = 5;
    GameObject player;
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
        animator = GetComponent<Animator>();
        StartCoroutine(DestroyObject());
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        switch (mobState)
        {
            case MobState.Idle:
                GoToEnemy();
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    mobState = MobState.Walking;
                }
                break;
            case MobState.Walking:
                GoToEnemy();
                animator.SetBool("isWalking", true);
                float distance = 0;
                if (FindEnemy())
                {
                    distance = Vector3.Distance(transform.position, FindEnemy().transform.position);
                }

                if (distance <= 1f)
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

            hp = hp - 1;

        }

        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (slaveKnight)
        {
            slaveKnight.DamageBoss(5);


        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private Enemy FindEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] enemy = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in enemy)
        {
            float distanceToGoldCoin = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToGoldCoin < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToGoldCoin;
                closestEnemy = currentEnemy;
            }
        }
        return closestEnemy;

    }

    public void SetSwordHitBoxActive()
    {
        skeletonMelee.isHitBoxActive = true;
    }
    public void SetSwordHitBoxDeActive()
    {
        skeletonMelee.isHitBoxActive = false;
    }

    private void GoToEnemy()
    {

        Vector3 targetPosition = new Vector3(0, 0, 0);

        FindEnemy();
        if (FindEnemy() != null)
        {
            targetPosition = FindEnemy().transform.position;
        }

        if (FindEnemy() == null && player != null)
        {
            targetPosition = player.transform.position + new Vector3(1, 1, 0);
        }
        Vector3 destination = targetPosition;
        Vector3 source = transform.position;
        Vector3 direction;
        direction = destination - source;
        direction.Normalize();
        transform.position += direction * Time.deltaTime * 2.5f;

        int scaleX = 1;
        if (targetPosition.x < 0)
        {
            scaleX = -1;
        }

        if (targetPosition.x >= 0)
        {
            scaleX = 1;
        }
        transform.localScale = new Vector3(-scaleX, 1, 1);
    }

}
