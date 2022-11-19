using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
  
{
    protected GameObject player;
    public Crystal crystal;
    public SmallHealthPot smallhealthPot;
    public LargeHealthPot largehealthPot;
    public Magnet magnet;
    public GoldCoin goldCoin;
    public AudioManager audioManager;
    public GoldPotion goldPotion;
    public Flame flame;
    public BloodSplash bloodSplash;
    public DamageBoostPot damageBoostPot;
    public float speed = 2f;
    public Animator animator;
    public  bool isDead = false;
    public float enemyMaxHP = 2f;
    public float enemyHP;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    protected  int sec;    
    public bool isTrack = true;
    protected bool isInvincible;
    [SerializeField] TMP_Text damageNumber;
    GameObject healthBar;
    


    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyHP = enemyMaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();       
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar = transform.GetChild(0).gameObject;
    }


   
    protected virtual void Update()
    {     
        sec = (int)Time.timeSinceLevelLoad;       
        GoToPlayer();
    }

    public void Damage(float damageValue)
    {       
        if (!isInvincible)
        {
            StartCoroutine(InvincibleFrames());
            enemyHP -= damageValue;
            StartCoroutine(DamagePopUp(damageValue));
           


            if (enemyHP <= 0)
            {
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                GameManager.isEnemyDeadSound = true;
                Instantiate(crystal, transform.position, Quaternion.identity);
                int randomIndex = UnityEngine.Random.Range(0, 201);

                if (randomIndex >= 0 && randomIndex <= 10 )
                {

                    Vector3 smallHpPot = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z);
                    Instantiate(smallhealthPot, smallHpPot, Quaternion.identity);
                }

               
                if (randomIndex >= 11 && randomIndex <= 15)
                {
                    Vector3 largeHpPot = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, transform.position.z);
                    Instantiate(largehealthPot, largeHpPot, Quaternion.identity);
                }

               
                if (randomIndex >= 16 && randomIndex <= 25)
                {
                    Vector3 magnetPot = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, transform.position.z);
                    Instantiate(magnet, magnetPot, Quaternion.identity);
                }
                //16 20
                if (randomIndex >= 16 && randomIndex <= 20)
                {
                    Vector3 goldcoin = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, transform.position.z);
                    Instantiate(goldCoin, goldcoin, Quaternion.identity);
                }
                if (randomIndex >= 21 && randomIndex <= 30)
                {
                    Vector3 flameP = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                    Instantiate(flame, flameP, Quaternion.identity);
                }


                //if (TitleManager.saveData.isGoldPotionActive == true)
                //{
                //    if (randomIndex >= 31 && randomIndex <= 39)
                //    {
                //        Vector3 goldCoinPotion = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                //        Instantiate(goldPotion, goldCoinPotion, Quaternion.identity);
                //    }
                //}

                if (randomIndex >= 40 && randomIndex <= 43)
                {
                    Vector3 damageBoostPotPo = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.6f, transform.position.z);
                    Instantiate(damageBoostPot, damageBoostPotPo, Quaternion.identity);
                }

                this.enabled = false;
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                healthBar.SetActive(false);
                StartCoroutine(Destroy());

               
            }
        }

    }

    public IEnumerator InvincibleFrames()
    {
        //isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        //isInvincible = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        IceSpike iceSpike = collision.gameObject.GetComponent<IceSpike>();
        if(iceSpike != null)
        {
            StartCoroutine(Freeze());
        }

        Dagger dagger = collision.gameObject.GetComponent<Dagger>();
        if(dagger != null)
        {
            StartCoroutine(Slow());
        }
        //PosionArrow poisonArrow  = collision.gameObject.GetComponent<PosionArrow>();
        //if (poisonArrow != null)
        //{
        //    StartCoroutine(Poison());
        //}

        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            if (player.OnDamage())
            {                
                Damage(enemyHP);                                
            }           
        }
    }

    public void AddHP(float hp)
    {
        enemyMaxHP = enemyMaxHP + hp;
    }    
    public  void GoToPlayer()
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

            bool isAttacking1 = false;

            var dx = source.x - destination.x;
            var dy = source.y - destination.y;

            //if (Mathf.Abs(dx) <= 3 && Mathf.Abs(dy) <= 3)
            //{
            //    isAttacking1 = true;
            //}

            //animator.SetBool("isAttacking", isAttacking1);

        }
    }

    public IEnumerator Freeze()
    {
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = Color.cyan;
        float speed1 = speed; 
        speed = (float)(speed * 0);
        yield return new WaitForSeconds(3f);
        spriteRenderer.color = Color.white;
        speed = speed1;
    }

    public IEnumerator Slow()
    {
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = Color.grey;
        float speed1 = speed;
        speed = (float)(speed * 0.75);
        yield return new WaitForSeconds(3f);
        spriteRenderer.color = Color.white;
        speed = speed1;
    }

    public IEnumerator Poison(int numberOfPoisonTicks, float poisonDotDamage)
    {
        
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.green;
        for (int i = 0; i < numberOfPoisonTicks; i++)
        {
            Damage(poisonDotDamage);
            yield return new WaitForSeconds(1f);
        }
        spriteRenderer.color = Color.white;
    }

    IEnumerator DamagePopUp(float damage)
    {
        while (true)
        {
            damageNumber.transform.position = transform.position + new Vector3(0, 1, 0);
            damageNumber.text = damage.ToString();
            damageNumber.transform.localScale = new Vector3(1, 1, 1);   
            damageNumber.transform.position += (transform.position + new Vector3(0, 0.005f, 0)) * 1 * Time.deltaTime;
            damageNumber.transform.localScale = new Vector3(1, 1, 1);
            yield return new WaitForSeconds(1f);
            damageNumber.transform.position = transform.position + new Vector3(0, 1, 0);
            damageNumber.transform.localScale = new Vector3(1, 1, 1);
            damageNumber.text = "";
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
        

}
