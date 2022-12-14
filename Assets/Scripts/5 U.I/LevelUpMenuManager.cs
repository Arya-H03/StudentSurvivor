using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class LevelUpMenuManager : MonoBehaviour
{
    [SerializeField] BaseWeapon[] KnightWeaponSpawners;
    [SerializeField] BaseWeapon[] KnightWeapons;
    [SerializeField] BaseWeapon[] RangerWeaponSpawner;
    [SerializeField] BaseWeapon[] RangerWeapons;
    [SerializeField] BaseWeapon[] WitchWeapons;
    [SerializeField] BaseWeapon[] WitchWeaponSpawner;
    [SerializeField] Image[] images;
    [SerializeField] TMP_Text[] lvlText;
    [SerializeField] GameObject levelUpMenu;
    [SerializeField] PlayerRanger playerRanger;
    [SerializeField] PlayerKnight playerKnight;
    [SerializeField] PlayerWitch playerWitch;
    [SerializeField] RangerArrow rangerArrow;

    private bool isKnight;
    private bool isRanger;
    private bool isWitch;
    Player player;
    int level = 0;
    public static int random1;
    public static int random2;
    public static int random3;
    public PlayerCamera playerCamera;

    void Start()
    {
        if(PlayerCharacterManager.isKnight == true)
        {
            player = GetComponent<PlayerKnight>();
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            player = GetComponent<PlayerRanger>();
        }

        isKnight = PlayerCharacterManager.isKnight;
        isRanger = PlayerCharacterManager.isRanger;
        isWitch = PlayerCharacterManager.isWitch;


    }

   
    public void Axe()
    {
        KnightWeapons[1].LevelUp();

        lvlText[1].text = "Lvl " + KnightWeapons[0].level.ToString();
        
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        images[1].color = Color.white;

        

        Time.timeScale = 1;

    }public void SwordAttack()
    {

        KnightWeapons[0].LevelUp();
        lvlText[0].text = "Lvl " + level.ToString();
        
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();

        Time.timeScale = 1;

    }
    public void Scythe()
    {
        KnightWeapons[2].LevelUp();
        KnightWeaponSpawners[0].LevelUp();
        lvlText[2].text = "Lvl " + KnightWeapons[1].level.ToString();
        
        levelUpMenu.SetActive(false);
        images[2].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }

    public void Clone()
    {
        KnightWeapons[3].LevelUp();
        KnightWeaponSpawners[1].LevelUp();
        lvlText[3].text = "Lvl " + KnightWeapons[2].level.ToString();
      
        levelUpMenu.SetActive(false);
        images[3].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }

    public void FlyingSkull()
    {
        //KnightWeapons[3].LevelUp(2);
        lvlText[4].text = "Lvl " + KnightWeapons[3].level.ToString();
        WitchWeaponSpawner[1].LevelUp();
        WitchWeapons[1].LevelUp();
        levelUpMenu.SetActive(false);
        images[4].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }

    public void FireBall()
    {
        WitchWeaponSpawner[5].LevelUp();
        WitchWeapons[5].LevelUp();
        lvlText[5].text = "Lvl " + KnightWeapons[4].level.ToString();

        levelUpMenu.SetActive(false);
        images[5].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }
    public void MeteorShower()
    {
        WitchWeaponSpawner[4].LevelUp();
        WitchWeapons[4].LevelUp();
        lvlText[8].text = "Lvl " + KnightWeapons[5].level.ToString();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        images[6].color = Color.white;

        Time.timeScale = 1;

    }

    public void SpeedBoost()
    {
        int lvl=0;
        if (isKnight == true)
        {
            playerKnight.AddSpeed();
        }

        if (isRanger == true)
        {
            playerRanger.AddSpeed();
        }
        if (isWitch == true)
        {
            playerWitch.AddSpeed();
        }
        lvl++;
        lvlText[6].text = "Lvl " +lvl.ToString();
        
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();


        Time.timeScale = 1;


    }

    public void AddMaxHP()
    {
        int lvl = 0;
        if(isKnight == true)
        {
            playerKnight.AddMaxHP(1);
        }

        if (isRanger == true)
        {
            playerRanger.AddMaxHP(1);
        }

        if (isWitch == true)
        {
            playerWitch.AddMaxHP(1);
        }

        lvl++;
        lvlText[7].text = "Lvl " + lvl.ToString();
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();

        Time.timeScale = 1;
    }
    public void Dagger()
    {
        KnightWeapons[5].LevelUp();
        KnightWeaponSpawners[3].LevelUp();

        //lvlText[9].text = "Lvl " + KnightWeapons[6].level.ToString();

        levelUpMenu.SetActive(false);
        //images[7].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }

    public void IceSpike()
    {
        WitchWeaponSpawner[2].LevelUp();
        WitchWeapons[2].LevelUp();
        

        levelUpMenu.SetActive(false);
        images[8].color = Color.white;
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerArrowDamage()
    {
        RangerWeapons[1].LevelUp();


        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerPierce()
    {
        rangerArrow.Pierce();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void ActivatePoisonArrow()
    {
        rangerArrow.PoisonArrow();


        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerAxe()
    {
        RangerWeapons[0].LevelUp();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerSpear()
    {
        RangerWeapons[5].LevelUp();
        RangerWeaponSpawner[0].LevelUp();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerDagger()
    {
        RangerWeapons[4].LevelUp();
        RangerWeaponSpawner[1].LevelUp();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RainOfArrows()
    {
        RangerWeapons[2].LevelUp();
        playerRanger.ActivateRainOfArrow();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }
    public void RangerBeams()
    {
        RangerWeapons[3].LevelUp();
        playerRanger.ActivateRangerBeam();
        

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void RangerArrowNumberBuff()
    {
        playerRanger.IncreaseNumberOfArrow();

        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;

    }

    public void WitchVoidBolt()
    {
        WitchWeaponSpawner[0].LevelUp();
        WitchWeapons[0].LevelUp();
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }
    public void WitchRaiseSkeleton()
    {
        WitchWeaponSpawner[3].LevelUp();
        WitchWeapons[3].LevelUp();
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void SpreadArrow()
    {
        RangerWeaponSpawner[2].LevelUp();
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }

    public void KnightShieldWall()
    {
        KnightWeapons[2].LevelUp();
        KnightWeaponSpawners[3].LevelUp();
        levelUpMenu.SetActive(false);
        playerCamera.EndBlur();
        Time.timeScale = 1;
    }



    public void OnClickKnightAbility1()
    {
        if (isKnight == true)
        {
            switch (random1)
            {
                case 0:
                    SwordAttack();
                    break;

                case 1:
                    Axe();
                    break;
                case 2:
                    Scythe();
                    break;
                case 3:
                    Clone();
                    break;
                case 4:
                    KnightShieldWall();
                    break;
                case 5:
                    Dagger();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }

        if (isRanger == true)
        {
            switch (random1)
            {
                case 0:
                    RangerArrowDamage();
                    break;
                case 1:
                    RangerAxe();
                    break;
                case 2:
                    RangerSpear();
                    break;
                case 3:
                    RangerDagger();
                    break;
                case 4:
                    AddMaxHP();
                    break;
                case 5:
                    SpeedBoost();
                    break;
                case 6:
                    RainOfArrows();
                    break;
                case 7:
                    RangerBeams();
                    break;
                case 8:
                    RangerArrowNumberBuff();
                    break;
                case 9:
                    RangerPierce();
                    break;
                case 10:
                    ActivatePoisonArrow();
                    break;
                case 11:
                    SpreadArrow();
                    break;
                default:
                    break;


            }
        }

        if (isWitch == true)
        {
            switch (random1)
            {
                case 0:
                    WitchVoidBolt();
                    break;
                case 1:
                    FlyingSkull(); ;
                    break;
                case 2:
                    IceSpike();
                    break;
                case 3:
                    WitchRaiseSkeleton();
                    break;
                case 4:
                    MeteorShower();
                    break;
                case 5:
                    FireBall();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }
    
    }

    public void OnClickKnightAbility2()
    {
        if (isKnight == true)
        {
            switch (random2)
            {
                case 0:
                    SwordAttack();
                    break;

                case 1:
                    Axe();
                    break;
                case 2:
                    Scythe();
                    break;
                case 3:
                    Clone();
                    break;
                case 4:
                    KnightShieldWall();
                    break;
                case 5:
                    Dagger();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }

        if (isRanger == true)
        {
            switch (random2)
            {
                case 0:
                    RangerArrowDamage();
                    break;
                case 1:
                    RangerAxe();
                    break;
                case 2:
                    RangerSpear();
                    break;
                case 3:
                    RangerDagger();
                    break;
                case 4:
                    AddMaxHP();
                    break;
                case 5:
                    SpeedBoost();
                    break;
                case 6:
                    RainOfArrows();
                    break;
                case 7:
                    RangerBeams();
                    break;
                case 8:
                    RangerArrowNumberBuff();
                    break;
                case 9:
                    RangerPierce();
                    break;
                case 10:
                    ActivatePoisonArrow();
                    break;
                case 11:
                    SpreadArrow();
                    break;
                default:
                    break;
            }

        }

        if (isWitch == true)
        {
            switch (random2)
            {
                case 0:
                    WitchVoidBolt();
                    break;
                case 1:
                    FlyingSkull(); ;
                    break;
                case 2:
                    IceSpike();
                    break;
                case 3:
                    WitchRaiseSkeleton();
                    break;
                case 4:
                    MeteorShower();
                    break;
                case 5:
                    FireBall();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }
    }

    public void OnClickKnightAbility3()
    {
        if (isKnight == true)
        {
            switch (random3)
            {
                case 0:
                    SwordAttack();
                    break;

                case 1:
                    Axe();
                    break;
                case 2:
                    Scythe();
                    break;
                case 3:
                    Clone();
                    break;
                case 4:
                    KnightShieldWall();
                    break;
                case 5:
                    Dagger();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }

        if (isRanger == true)
        {
            switch (random3)
            {
                case 0:
                    RangerArrowDamage();
                    break;
                case 1:
                    RangerAxe();
                    break;
                case 2:
                    RangerSpear();
                    break;
                case 3:
                    RangerDagger();
                    break;
                case 4:
                    AddMaxHP();
                    break;
                case 5:
                    SpeedBoost();
                    break;
                case 6:
                    RainOfArrows();
                    break;
                case 7:
                    RangerBeams();
                    break;
                case 8:
                    RangerArrowNumberBuff();
                    break;
                case 9:
                    RangerPierce();
                    break;
                case 10:
                    ActivatePoisonArrow();
                    break;
                case 11:
                    SpreadArrow();
                    break;
                default:
                    break;
            }
        }

        if (isWitch == true)
        {
            switch (random3)
            {
                case 0:
                    WitchVoidBolt();
                    break;
                case 1:
                    FlyingSkull(); ;
                    break;
                case 2:
                    IceSpike();
                    break;
                case 3:
                    WitchRaiseSkeleton();
                    break;
                case 4:
                    MeteorShower();
                    break;
                case 5:
                    FireBall();
                    break;
                case 6:
                    AddMaxHP();
                    break;
                case 7:
                    SpeedBoost();
                    break;
                default:
                    break;


            }
        }
    }

}
