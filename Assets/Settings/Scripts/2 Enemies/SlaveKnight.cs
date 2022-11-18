using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Windows;

public class SlaveKnight : MonoBehaviour
{
    GameObject player;
    [SerializeField] GoldCoin goldCoin;
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


    // Start is called before the first frame update
    void Start()
    {
        bossHP = bossMaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();    
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(BossCameraCoroutine());

    }

    //void secondGear()
    //{
    //    if (bossHP < bossMaxHP/2)
    //    {
    //        speed+= 
    //    }
    //}



    void Update()
    {

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

        }

        if (isBoss25per == true && checkBossIs25Per == true)
        {

            IncreaseSpeed25P(isBoss25per);

        }

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

            bool isAttacking1 = false;

            var dx = source.x - destination.x;
            var dy = source.y - destination.y;

            


            if (Mathf.Abs(dx) <= 5 && Mathf.Abs(dy) <= 5)
            {
                isAttacking1 = true; 
            }

            animator.SetBool("isAttacking", isAttacking1);


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

               


               

                for(int i=0; i<50; i++)
                {
                    Vector3 spawnPosition = Random.insideUnitCircle.normalized * 2f;
                    spawnPosition += transform.position;
                    Instantiate(goldCoin, spawnPosition, Quaternion.identity);
                }


                



                Destroy(gameObject);



                





            }
        }

    }

    IEnumerator InvincibleFrames()
    {
        bool isAttacking = false;
        isInvincible = true;
        spriteRenderer.color = Color.red;
        isAttacking = true;
        animator.SetBool("isAttacking", isAttacking);

        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.white;
        isInvincible = false;
        isAttacking=false;
        animator.SetBool("isAttacking", isAttacking);
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.OnDamageBoss();
            
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

    private void IncreaseSpeed25P(bool isBoss50per)
    {
        if (isBoss25per == true)
        {
            checkBossIs25Per = false;
            speed = speed * 2;

        }
    }



}
