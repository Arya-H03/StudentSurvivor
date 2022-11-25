using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneAttack : BaseWeapon
{
    GameObject player;
    [SerializeField] KnightSword cloneSword;
    Animator animator;

    enum CloneState
    {
        Idle = 0,
        Walking = 1,
        Attacking = 2,
 
    }

    CloneState cloneState = CloneState.Idle;
    float waitTimer = 1f;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CloneSpawnCoroutine());
        animator = GetComponent<Animator>();
    }

    IEnumerator CloneSpawnCoroutine()
    {       
            yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    void Update()
    {


        switch (cloneState)
        {
            case CloneState.Idle:
                GoToEnemy();
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    cloneState = CloneState.Walking;
                }

                break;
            case CloneState.Walking:
                GoToEnemy();
                animator.SetBool("isRunning", true);
                float distance = 0;
                if (FindEnemy())
                {
                    distance = Vector3.Distance(transform.position, FindEnemy().transform.position);
                }
                
                if (distance <= 1f)
                {
                    cloneState = CloneState.Attacking;
                }
                break;
            case CloneState.Attacking:
                GoToEnemy();
                animator.SetBool("isRunning", false);
                animator.SetTrigger("Attack");
                cloneState = CloneState.Idle;
                waitTimer = 1f;
                break;
            default:
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(damage);
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
        }
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
        cloneSword.isHitBoxActive = true;
    }
    public void SetSwordHitBoxDeActive()
    {
        cloneSword.isHitBoxActive = false;
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
