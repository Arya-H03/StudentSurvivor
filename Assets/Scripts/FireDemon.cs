using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDemon : MonoBehaviour
{
    GameObject player;
    [SerializeField] GoldCoin goldCoin;
    [SerializeField] Crystal crystal;
    [SerializeField] float speed = 1f;
    Animator animator;
    public float bossMaxHP = 10f;
    public float bossHP;
    SpriteRenderer spriteRenderer;
    public bool isTrack = true;
    bool isInvincible;
    [SerializeField] BossMelee bossMelee;
    [SerializeField] GameObject fireHand;
    [SerializeField] GameObject fireSkull;
    private bool isHit = false;
    private int shoot1 = 1;

    enum FireDemonState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
            Hit = 3
    }

    FireDemonState fireDemonState = FireDemonState.Idle;
    float waitTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bossHP = bossMaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(BossCameraCoroutine());
        StartCoroutine(FireHand());
        StartCoroutine(FireSkullSpawn());
    
    }

    void Update()
    {
        if(isHit == true)
        {
            fireDemonState = FireDemonState.Hit;
            isHit = false;
        }
        switch (fireDemonState)
        {
            case FireDemonState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    fireDemonState = FireDemonState.Chasing;
                }
                break;
            case FireDemonState.Chasing:
                float distance = 0;
                if (player)
                {
                    distance = Vector3.Distance(transform.position, player.transform.position);
                }
                GoToPlayer();
                animator.SetBool("isWalking", true);
                if (distance <= 4f)
                {
                    fireDemonState = FireDemonState.Attacking;
                }

                if (shoot1 < 1)
                {
                    FireSkull();
                    shoot1 = 1;
                }

                break;
            case FireDemonState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                fireDemonState = FireDemonState.Idle;
                waitTimer = 1.5f;
                break;
            case FireDemonState.Hit:
                GoToPlayer();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Hit");
                fireDemonState = FireDemonState.Idle;
                waitTimer = 0.5f;
                
                break;

            default:
                break;


        }

        
        

    }

    internal void DamageBoss(float damageValue)
    {

        if (!isInvincible)
        {
            StartCoroutine(InvincibleFrames());


            bossHP -= damageValue;
            if (bossHP <= 0)
            {

                for (int i = 0; i < 50; i++)
                {
                    //Vector3 spawnPosition = Random.insideUnitCircle.normalized * 2f;
                    //spawnPosition += transform.position;
                    Instantiate(goldCoin, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }

    }

    private void GoToPlayer()
    {
        if (player != null)
        {

            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction;
            int scaleX = 1;
            if (!isTrack)
            {
                direction = new Vector3(1, 0, 0);


            }
            else
            {
                direction = destination - source;
            }
            direction.Normalize();
            transform.position += direction * Time.deltaTime * speed;



            if (direction.x < 0)
            {
                scaleX = -1;
            }
            transform.localScale = new Vector3(scaleX, 1, 1);

            var dx = source.x - destination.x;
            var dy = source.y - destination.y;
        }
    }

    IEnumerator InvincibleFrames()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        //spriteRenderer.color = Color.white;
        isInvincible = false;

    }

    IEnumerator FireHand()
    {
        
        yield return new WaitForSeconds(6f);
        Instantiate(fireHand, transform.position, Quaternion.identity);

    }

    IEnumerator BossCameraCoroutine()
    {
        if (PlayerCharacterManager.isKnight == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetKnight = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(3f);

            Camera.main.GetComponent<PlayerCamera>().targetKnight = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(1f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetRanger = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(3f);

            Camera.main.GetComponent<PlayerCamera>().targetRanger = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(1f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetWitch = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(3f);

            Camera.main.GetComponent<PlayerCamera>().targetWitch = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(1f);

            Time.timeScale = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.OnDamageBoss(5);

        }

        BaseWeapon baseWeapon = collision.gameObject.GetComponent<BaseWeapon>();
        if (baseWeapon)
        {
            isHit = true;
        }

    }





    public void SetSwordHitBoxActive()
    {
        bossMelee.isHitBoxActive = true;

    }
    public void SetSwordHitBoxDeActive()
    {
        bossMelee.isHitBoxActive = false;

    }


    IEnumerator FireSkullSpawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(4);
            shoot1 = 0;

        }

    }


    public void FireSkull()
    {
       
        if (transform.localScale.x >= 0)
        {
            fireSkull.transform.localScale = new Vector3(-1, 1, 1);
            Instantiate(fireSkull, transform.position, Quaternion.identity);

        }
        if (transform.localScale.x < 0)
        {
            fireSkull.transform.localScale = new Vector3(1, 1, 1);
            Instantiate(fireSkull, transform.position, Quaternion.identity);

        }
    }

}
