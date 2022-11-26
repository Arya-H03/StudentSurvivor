using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Windows;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class SlaveKnight : MonoBehaviour
{
    GameObject player;
    [SerializeField] GoldCoin goldCoin;
    GameObject obelisk;
    public Crystal crystal;
    [SerializeField] float speed = 1f;
    Animator animator;
    public float bossMaxHP = 10f;
    public float bossHP;
    protected bool isBoss50per;
    protected bool checkBossIs50Per = true;
    protected bool checkBossIs25Per = true;
    protected bool isBoss25per;  
    SpriteRenderer spriteRenderer;
    public bool isTrack = true;
    bool isInvincible;
    [SerializeField] BossMelee slaveKnightSword;

    [SerializeField] GameObject swordWall;
    [SerializeField] GameObject spear;
    [SerializeField] float waitTime = 5;
    int numberOfSword = 3;
    Vector3 obeliskSpawnPos;
    private int shoot1= 1;
    private int shoot2= 1;
    enum SlaveKnightState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2
    }

    SlaveKnightState slaveKnightState = SlaveKnightState.Idle;
    float waitTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bossHP = bossMaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();    
        player = GameObject.FindGameObjectWithTag("Player");
        obelisk = GameObject.FindGameObjectWithTag("Obelisk");
        StartCoroutine(BossCameraCoroutine());
        StartCoroutine(SwordWall());
        StartCoroutine(SpearSpawn());

        
    }

    void Update()
    {
        switch (slaveKnightState)
        {
            case SlaveKnightState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    slaveKnightState = SlaveKnightState.Chasing;
                }
                break;
            case SlaveKnightState.Chasing:
                float distance = Vector3.Distance(transform.position, player.transform.position);
                GoToPlayer();
                animator.SetBool("isWalking", true);
                if (shoot1<1)
                {
                    SpawnSwordWall();
                    shoot1= 1;
                }

                if (shoot2 < 1)
                {
                    SpawnSpear();
                    shoot2 = 1;
                }

                if (distance <= 2f)
                {
                    slaveKnightState = SlaveKnightState.Attacking;
                }
                break;
            case SlaveKnightState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                slaveKnightState = SlaveKnightState.Idle;
                waitTimer = 1f;
                break;
            default:
                break;

               
        }
        
        if (bossHP <= bossMaxHP * 0.5)
        {

            isBoss50per = true;

        }
        if (bossHP <= bossMaxHP * 0.25)
        {

            isBoss25per = true;

        }
        if (isBoss50per == true && checkBossIs50Per == true)
        {

            IncreaseSpeed50P(isBoss50per);
            numberOfSword = 4;

        }
        if (isBoss25per == true && checkBossIs25Per == true)
        {

            IncreaseSpeed25P(isBoss25per);
            numberOfSword = 5;
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
                TitleManager.saveData.isLevel2Unlocked = true;
                ActivateObelisk();
                for (int i=0; i<50; i++)
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
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.white;
        isInvincible = false;

    }

    IEnumerator BossCameraCoroutine()
    {
        if(PlayerCharacterManager.isKnight == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetKnight = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetKnight = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetRanger = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetRanger = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetWitch = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetWitch = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

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
    }

    private void IncreaseSpeed50P(bool isBoss50per)
    {
        if(isBoss50per == true)
        {
            checkBossIs50Per = false;
            speed = speed * 2;

        }
    }

    private void IncreaseSpeed25P(bool isBoss25per)
    {
        if (isBoss25per == true)
        {
            checkBossIs25Per = false;
            speed = speed * 2;

        }
    }



    public void SetSwordHitBoxActive()
    {
        slaveKnightSword.isHitBoxActive = true;
        
    }
    public void SetSwordHitBoxDeActive()
    {
        slaveKnightSword.isHitBoxActive = false;
        
    }

    IEnumerator SwordWall()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(5);
            shoot1= 0;
            
        }

    }

    IEnumerator SpearSpawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(3);
            shoot2= 0;

        }

    }


    public void SpawnSwordWall()
    {

        float d = 0.4f;
        float c = 0.4f;
        float aHalf = (numberOfSword - 1) * 0.5f;
        if (numberOfSword % 2 == 1)
        {
            Instantiate(swordWall, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);

            ;
            for (int i = 0; i < aHalf; i++)
            {
                d = d + 1f;
                Instantiate(swordWall, transform.position + new Vector3(0, d, 0), Quaternion.identity);

            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 1;
                Instantiate(swordWall, transform.position + new Vector3(0, c, 0), Quaternion.identity);


            }
        }


        if (numberOfSword % 2 == 0)
        {


            ;
            for (int i = 0; i < aHalf; i++)
            {

                Instantiate(swordWall, transform.position + new Vector3(0, d, 0), Quaternion.identity);
                d = d + 1f;

            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 1f;
                Instantiate(swordWall, transform.position + new Vector3(0, c, 0), Quaternion.identity);


            }
        }

    }

    public void SpawnSpear()
    {
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double angle = ConvertRadiansToDegrees(Math.Atan2(valueY, valueX));

        Instantiate(spear, transform.position, Quaternion.Euler(0, 0, (float)angle + 270));
    }

    public static double ConvertRadiansToDegrees(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }

    private void ActivateObelisk()
    {
        obelisk.GetComponent<EndLevelObelisk>().ActivateObelisk();
        
    }
}
