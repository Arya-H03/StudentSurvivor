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
    //public GoldPotion goldPotion;
    public Flame flame;
    public BloodSplash bloodSplash;
    public DamageBoostPot damageBoostPot;
    public float speed = 2f;
    public Animator animator;
    public  bool isDead = false;   
    public float enemyMaxHP;
    public float enemyBaseHp = 2f;
    public float enemyHP;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    protected  int sec;    
    public bool isTrack = true;
    protected bool isInvincible;
    GameObject healthBar;
    [SerializeField] GameObject damagePopUp;
    protected bool isHit = false;
    Material material;
    protected int playerLevel;
    [SerializeField] SimpleObjectPool enemyPool;
    


    private void OnEnable()
    {
        StartCoroutine(KillEnemyAfterTime());
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyHP = enemyMaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();       
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar = transform.GetChild(0).gameObject;
        material = spriteRenderer.material; 
       

    }


   
    protected virtual void Update()
    {     
        sec = (int)Time.timeSinceLevelLoad;       
        GoToPlayer();


        
    }

    public void Damage(float damageValue)
    {       
        if (!isInvincible && gameObject.activeInHierarchy)
        {

            StartCoroutine(InvincibleFrames());
            enemyHP -= damageValue;
            //StartCoroutine(DamagePopUp(damageValue));
            SpawnDamageNumber(damageValue);




            if (enemyHP <= 0)
            {
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                GameManager.isEnemyDeadSound = true;
                Instantiate(crystal, transform.position, Quaternion.identity);
                int randomIndex = UnityEngine.Random.Range(0, 100);

                if (randomIndex >= 0 && randomIndex <= 5 )
                {

                    Vector3 smallHpPot = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z);
                    Instantiate(smallhealthPot, smallHpPot, Quaternion.identity);
                }

               
                if (randomIndex >= 6 && randomIndex <= 8)
                {
                    Vector3 largeHpPot = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, transform.position.z);
                    Instantiate(largehealthPot, largeHpPot, Quaternion.identity);
                }

               
                if (randomIndex >= 9 && randomIndex <= 13)
                {
                    Vector3 magnetPot = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, transform.position.z);
                    Instantiate(magnet, magnetPot, Quaternion.identity);
                }
                //16 20
                if (randomIndex >= 14 && randomIndex <= 23)
                {
                    Vector3 goldcoin = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, transform.position.z);
                    Instantiate(goldCoin, goldcoin, Quaternion.identity);
                }

                if(PlayerCharacterManager.isWitch == true)
                {
                    if (randomIndex >= 21 && randomIndex <= 30)
                    {
                        Vector3 flameP = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                        Instantiate(flame, flameP, Quaternion.identity);
                    }

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
                KillEnemy();



            }
        }

    }

    public IEnumerator InvincibleFrames()
    {
        if (gameObject.activeInHierarchy)
        {
            //isInvincible = true;
            material.SetFloat("_Flash", 0.5f);
            yield return new WaitForSeconds(0.5f);
            material.SetFloat("_Flash", 0);

            //isInvincible = false;
        }

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
                enemyPool.ReturnObject(gameObject);                                
            }           
        }

        BaseWeapon baseWeapon =collision.gameObject.GetComponent<BaseWeapon>();
        if (baseWeapon)
        {
            isHit = true;
        }
    }

    public void AddHP()
    {
        
        Player player= GameObject.FindObjectOfType<Player>();
        enemyMaxHP = enemyBaseHp + player.currentLevel;



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
        if (gameObject.activeInHierarchy)
        {
            material.SetFloat("_UnderEffect", 1);
            material.SetFloat("_FrozenOrPoisoned", 1);
            float speed1 = speed;
            speed = (float)(speed * 0);
            yield return new WaitForSeconds(3f);
            material.SetFloat("_UnderEffect", 0);
            speed = speed1;
        }
    }

    public IEnumerator Slow()
    {
        if (gameObject.activeInHierarchy)
        {
            spriteRenderer.color = Color.grey;
            float speed1 = speed;
            speed = (float)(speed * 0.75);
            yield return new WaitForSeconds(3f);
            spriteRenderer.color = Color.white;
            speed = speed1;
        }
    }

    public IEnumerator Poison(int numberOfPoisonTicks, float poisonDotDamage)
    {
        if (gameObject.activeInHierarchy)
        {
            material.SetFloat("_UnderEffect", 1);
            material.SetFloat("_FrozenOrPoisoned", 0);
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < numberOfPoisonTicks; i++)
            {
                Damage(poisonDotDamage);
                yield return new WaitForSeconds(1f);
            }
            material.SetFloat("_UnderEffect", 0);
        }
    }

    //IEnumerator DamagePopUp(float damage)
    //{
    //    while (true)
    //    {
    //        damageNumber.transform.position = transform.position + new Vector3(0, 1, 0);
    //        damageNumber.text = damage.ToString();
    //        damageNumber.transform.localScale = new Vector3(1, 1, 1);   
    //        damageNumber.transform.position += (transform.position + new Vector3(0, 0.005f, 0)) * 1 * Time.deltaTime;
    //        damageNumber.transform.localScale = new Vector3(1, 1, 1);
    //        yield return new WaitForSeconds(1f);
    //        damageNumber.transform.position = transform.position + new Vector3(0, 1, 0);
    //        damageNumber.transform.localScale = new Vector3(1, 1, 1);
    //        damageNumber.text = "";
    //    }
    //}

    IEnumerator KillEnemyAfterTime()
    {
        yield return new WaitForSeconds(45);
        enemyPool.ReturnObject(gameObject);
    }

    private void SpawnDamageNumber(float damage)
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);
        damagePopUp.GetComponent<DamagePopUp>().damage = damage.ToString();
        Instantiate(damagePopUp, spawnPosition, Quaternion.identity);
    }

    protected virtual void KillEnemy()
    {
        enemyPool.ReturnObject(gameObject);
    }

   
}
