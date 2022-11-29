using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text scoreText;
    //[SerializeField] BaseWeapon[] weapons;
    [SerializeField] Enemy[] enemyTypes;   
    [SerializeField] TMP_Text expNumber;
    [SerializeField] TMP_Text hpNumber;
    [SerializeField] GameObject levelUpMenu;
    [SerializeField] TMP_Text goldAmount;
    [SerializeField] GameObject[] abilities;
    [SerializeField] Image ability1;
    [SerializeField] Image ability2;
    [SerializeField] Image ability3;
    [SerializeField] TMP_Text ability1Dis;
    [SerializeField] TMP_Text ability2Dis;
    [SerializeField] TMP_Text ability3Dis;
    [SerializeField] Sprite [] abilityIcons;
    Material material;
    SpriteRenderer spriteRenderer;
    //public Transform attackpoint;
    //public float attachRange = 0.5f;
    //public LayerMask enemyLayer;
    public int playerMaxFlame = 5;
    public int playerFlame = 0;
    public static bool isFlameFull = false;
    public Animator animator;
    public  float playerHP;
    public  float playerMaxHP = 3;
    public float speed = 1;
    public static bool isMagnetPotion;
    public static bool isGoldPotion;
    protected bool isDamageBoost;
    bool isInvincible;
    internal int score;
    internal int currentExp;
    internal int expToLevel = 5;
    internal int currentLevel;
    public PlayerCamera playerCamera;
    public int goldGainedByPlayer;
    public int EXPgained;


    public bool OnDamage()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(InvincibleCoroutine());
            playerHP -= 1;

            if (playerHP <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("AfterDeath");
                

                
            }
            return true;
        }
        return false;
    }

    public bool OnDamageBoss(float damage)
    {       
        if (!isInvincible)
        {
            isInvincible = true;
            playerHP = (float)(playerHP - damage);
            if (playerHP <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("AfterDeath");
            }
            return true;
        }
        return false;
    }
    protected virtual void Start()
    {
        playerHP = playerMaxHP;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //isAttacking = true;

        material = spriteRenderer.material;
             
    }
    IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        material.SetFloat("_Flash", 0.5f);
        yield return new WaitForSeconds(0.4f);
        material.SetFloat("_Flash", 0f);
        isInvincible = false;
    }
    

    protected virtual void Update()
    {        
        
            if (playerFlame == playerMaxFlame)
            {
                isFlameFull = true;
            }
            if (playerFlame > playerMaxFlame)
            {
                playerFlame = playerMaxFlame;
            }
            int randomInedx = UnityEngine.Random.Range(1, 4);

            //if(isAttacking == true)
            //{
            //    StartCoroutine(PlayerAttacks());            
            //}

            StartCoroutine(MagnetPotionCoroutine());
            StartCoroutine(GoldPotionCoroutine());
            goldAmount.text = TitleManager.saveData.goldCoins.ToString();
            expNumber.text = currentExp.ToString() + " / " + expToLevel.ToString();
            hpNumber.text = playerHP.ToString() + " / " + playerMaxHP.ToString();
            levelText.text = currentLevel.ToString();
            scoreText.text = score.ToString();

            isInvincible = false;
        if(Time.timeScale == 1)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            bool isRunning = false;

            if (inputX != 0 || inputY != 0)
            {
                isRunning = true;
            }

            animator.SetBool("isRunning", isRunning);

            transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

            float scaleX = 1;

            if (inputX > 0)
            {
                scaleX = -1;
            }
            else if (inputX < 0)
            {
                scaleX = 1;
            }
            else if (inputX == 0)
            {
                scaleX = transform.localScale.x;
            }

            transform.localScale = new Vector3(scaleX, 1, 1);

        }



    }

    internal void AddExp()
    {
        
        currentExp++;
        AfterDeath.EXPgained ++;
        if(currentExp == expToLevel)
        {           
            currentExp = 0;
            expToLevel = ((currentLevel + 2) * (currentLevel + 2) +1);
            GameManager.isLevelUpSound = true;
            currentLevel++;
            RandomizeWeapon();
            ShowAbility();

            levelUpMenu.SetActive(true);
            Time.timeScale = 0;
            playerCamera.StartBlur();

            playerMaxHP++;
            playerHP = playerMaxHP;

            for (int i = 0; i < enemyTypes.Length; i++)
            {
                enemyTypes[i].AddHP(1f);
            }

        }
    }
    internal void AddHP(float hp)
    {
        if(playerHP < playerMaxHP)
        {
            playerHP = playerHP + hp ;

            if(playerHP > playerMaxHP)
            {
                playerHP = playerMaxHP;
            } 
        }
    }

    internal void AddMaxHP(float hp)
    {
       
            playerMaxHP = playerMaxHP + hp;

    }

    internal void AddScore()
    {
        score += 1 * (currentLevel + 1);
    }

    public void AddSpeed()
    {
        speed = speed + 0.25f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Magnet magnet = collision.gameObject.GetComponent<Magnet>();
        if (magnet)
        {
            isMagnetPotion = true;

        }

        GoldPotion goldPotion = collision.gameObject.GetComponent<GoldPotion>();
        if (goldPotion)
        {
            isGoldPotion = true;
        }

        DamageBoostPot damageBoostPot = collision.gameObject.GetComponent<DamageBoostPot>();
        
        if (damageBoostPot)
        {
            isDamageBoost = true;
            PlayerDamageBoost();
        }

       
    }
    IEnumerator MagnetPotionCoroutine()
    {       
            if (isMagnetPotion == true)
            {
                yield return new WaitForSeconds(3f);

            isMagnetPotion = false;
            }        
    }

    IEnumerator GoldPotionCoroutine()
    {
        if (isGoldPotion == true)
        {
            yield return new WaitForSeconds(3f);
            isGoldPotion = false;
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if(attackpoint != null)
    //    {
    //        Gizmos.DrawWireSphere(attackpoint.position, attachRange);
    //    }        
    //}

    private void RandomizeWeapon()
    {
        if(PlayerCharacterManager.isKnight == true)
        {
            LevelUpMenuManager.random1 = UnityEngine.Random.Range(0, 8);
            LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, 8);
            while (LevelUpMenuManager.random1 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, 8);
            }
            LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, 8);
            while (LevelUpMenuManager.random3 == LevelUpMenuManager.random1 || LevelUpMenuManager.random3 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, 8);
            }
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            LevelUpMenuManager.random1 = UnityEngine.Random.Range(0, abilities.Count()+6);
            LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, abilities.Count()+6);
            while (LevelUpMenuManager.random1 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, abilities.Count()+6);
            }
            LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, abilities.Count()+6);
            while (LevelUpMenuManager.random3 == LevelUpMenuManager.random1 || LevelUpMenuManager.random3 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, abilities.Count()+6);
            }
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            LevelUpMenuManager.random1 = UnityEngine.Random.Range(0, abilities.Count()+2);
            LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, abilities.Count()+2);
            while (LevelUpMenuManager.random1 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random2 = UnityEngine.Random.Range(0, abilities.Count()+2);
            }
            LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, abilities.Count()+2);
            while (LevelUpMenuManager.random3 == LevelUpMenuManager.random1 || LevelUpMenuManager.random3 == LevelUpMenuManager.random2)
            {
                LevelUpMenuManager.random3 = UnityEngine.Random.Range(0, abilities.Count()+2);
            }
        }



    }

    private void ShowAbility()
    {

        ability1.sprite = abilityIcons[LevelUpMenuManager.random1];
        ability2.sprite = abilityIcons[LevelUpMenuManager.random2];
        ability3.sprite = abilityIcons[LevelUpMenuManager.random3];

        if (PlayerCharacterManager.isRanger == true)
        {
            switch (LevelUpMenuManager.random1)
            {
                case 0:                   
                    ability1Dis.text = "Arrow damage";
                    break;
                case 1:
                    ability1Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability1Dis.text = "Throw spear";
                    break;
                case 3:
                    ability1Dis.text = "Fan of knifes";
                    break;
                case 4:
                    ability1Dis.text = "Increase max HP";
                    break;
                case 5:
                    ability1Dis.text = "Increase movement speed";
                    break;
                case 6:
                    ability1Dis.text = "Rain of arrows";
                    break;
                case 7:
                    ability1Dis.text = "Beam Shot";
                    break;
                case 8:
                    ability1Dis.text = "Volley";
                    break;
                case 9:
                    ability1Dis.text = "Pierce";
                    break;
                case 10:
                    ability1Dis.text = "Poison arrow";
                    break;
                case 11:
                    ability1Dis.text = "Spread Shot";
                    break;
                default:
                    break;


            }

            switch (LevelUpMenuManager.random2)
            {
                case 0:
                    ability2Dis.text = "Arrow damage";
                    break;
                case 1:
                    ability2Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability2Dis.text = "Throw spear";
                    break;
                case 3:
                    ability2Dis.text = "Fan of knifes";
                    break;
                case 4:
                    ability2Dis.text = "Increase max HP";
                    break;
                case 5:
                    ability2Dis.text = "Increase movement speed";
                    break;
                case 6:
                    ability2Dis.text = "Rain of arrows";
                    break;
                case 7:
                    ability2Dis.text = "Beam Shot";
                    break;
                case 8:
                    ability2Dis.text = "Volley";
                    break;
                case 9:
                    ability2Dis.text = "Pierce";
                    break;
                case 10:
                    ability2Dis.text = "Poison arrow";
                    break;
                case 11:
                    ability1Dis.text = "Spread Shot";
                    break;
                default:
                    break;


            }

            switch (LevelUpMenuManager.random3)
            {
                case 0:
                    ability3Dis.text = "Arrow damage";
                    break;
                case 1:
                    ability3Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability3Dis.text = "Throw spear";
                    break;
                case 3:
                    ability3Dis.text = "Fan of knifes";
                    break;
                case 4:
                    ability3Dis.text = "Increase max HP";
                    break;
                case 5:
                    ability3Dis.text = "Increase movement speed";
                    break;
                case 6:
                    ability3Dis.text = "Rain of arrows";
                    break;
                case 7:
                    ability3Dis.text = "Beam Shot";
                    break;
                case 8:
                    ability3Dis.text = "Volley";
                    break;
                case 9:
                    ability3Dis.text = "Pierce";
                    break;
                case 10:
                    ability3Dis.text = "Poison arrow";
                    break;
                case 11:
                    ability1Dis.text = "Spread Shot";
                    break;
                default:
                    break;


            }
        }

        if (PlayerCharacterManager.isKnight == true)
        {
            switch (LevelUpMenuManager.random1)
            {
                case 0:
                    ability1Dis.text = "Sword Attack";
                    break;
                case 1:
                    ability1Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability1Dis.text = "Throw Scythe";
                    break;
                case 3:
                    ability1Dis.text = "Clone!!!!";
                    break;
                case 4:
                    ability1Dis.text = "Unleash a wall of sword";
                    break;
                case 5:
                    ability1Dis.text = "Spray daggers";
                    break;
                case 6:
                    ability1Dis.text = "Increase movement speed ";
                    break;
                case 7:
                    ability1Dis.text = "Increase maximum health";
                    break;               
                default:
                    break;


            }

            switch (LevelUpMenuManager.random2)
            {
                case 0:
                    ability2Dis.text = "Sword Attack";
                    break;
                case 1:
                    ability2Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability2Dis.text = "Throw Scythe";
                    break;
                case 3:
                    ability2Dis.text = "Clone!!!!";
                    break;
                case 4:
                    ability2Dis.text = "Unleash a wall of sword";
                    break;
                case 5:
                    ability2Dis.text = "Spray daggers";
                    break;
                case 6:
                    ability2Dis.text = "Increase movement speed ";
                    break;
                case 7:
                    ability2Dis.text = "Increase maximum health";
                    break;
                default:
                    break;


            }

            switch (LevelUpMenuManager.random3)
            {
                case 0:
                    ability3Dis.text = "Sword Attack";
                    break;
                case 1:
                    ability3Dis.text = "Rotaing Axe";
                    break;
                case 2:
                    ability3Dis.text = "Throw Scythe";
                    break;
                case 3:
                    ability3Dis.text = "Clone!!!!";
                    break;
                case 4:
                    ability3Dis.text = "Unleash a wall of sword";
                    break;
                case 5:
                    ability3Dis.text = "Spray daggers";
                    break;
                case 6:
                    ability3Dis.text = "Increase movement speed ";
                    break;
                case 7:
                    ability3Dis.text = "Increase maximum health";
                    break;
                default:
                    break;
            }
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            switch (LevelUpMenuManager.random1)
            {
                case 0:
                    ability1Dis.text = "Buff Death Bolt";
                    break;
                case 1:
                    ability1Dis.text = "Flying Skull";
                    break;
                case 2:
                    ability1Dis.text = "Ice Spikes";
                    break;
                case 3:
                    ability1Dis.text = "Raise Skeleton";
                    break;
                case 4:
                    ability1Dis.text = "Meteor Shower";
                    break;
                case 5:
                    ability1Dis.text = "Fire Ball";
                    break;
                case 6:
                    ability1Dis.text = "Increase max HP";
                    break;
                case 7:
                    ability1Dis.text = "Increase movement speed";
                    break;
                default:
                    break;


            }

            switch (LevelUpMenuManager.random2)
            {
                case 0:
                    ability2Dis.text = "Buff Death Bolt";
                    break;
                case 1:
                    ability2Dis.text = "Flying Skull";
                    break;
                case 2:
                    ability2Dis.text = "Ice Spikes";
                    break;
                case 3:
                    ability2Dis.text = "Raise Skeleton";
                    break;
                case 4:
                    ability2Dis.text = "Meteor Shower";
                    break;
                case 5:
                    ability2Dis.text = "Fire Ball";
                    break;
                case 6:
                    ability2Dis.text = "Increase max HP";
                    break;
                case 7:
                    ability2Dis.text = "Increase movement speed";
                    break;
                default:
                    break;


            }

            switch (LevelUpMenuManager.random3)
            {
                case 0:
                    ability3Dis.text = "Buff Death Bolt";
                    break;
                case 1:
                    ability3Dis.text = "Flying Skull";
                    break;
                case 2:
                    ability3Dis.text = "Ice Spikes";
                    break;
                case 3:
                    ability3Dis.text = "Raise Skeleton";
                    break;
                case 4:
                    ability3Dis.text = "Meteor Shower";
                    break;
                case 5:
                    ability3Dis.text = "Fire Ball";
                    break;
                case 6:
                    ability3Dis.text = "Increase max HP";
                    break;
                case 7:
                    ability3Dis.text = "Increase movement speed";
                    break;
                default:
                    break;

            }
        }

    }
    public float GetHPRatio()
    {
        return(float)playerHP / playerMaxHP;
    }

    IEnumerator PlayerDamageBoosted()
    {       
    //       BaseWeapon.damage = BaseWeapon.damage + 2f;
    //    material.SetFloat("_IsDamageBuff", 1);
           yield return new WaitForSeconds(3);
        //material.SetFloat("_IsDamageBuff", 0);
        //isDamageBoost = false;
        //   BaseWeapon.damage = BaseWeapon.damage - 2f;        
    }

    private void PlayerDamageBoost()
    {
        if (isDamageBoost == true)
        {
            StartCoroutine(PlayerDamageBoosted());

        }
    }

    //public void PlayerDeath()
    //{
    //    Destroy(gameObject);
    //    SceneManager.LoadScene("AfterDeath");
    //    isDead = false;
    //}
}

