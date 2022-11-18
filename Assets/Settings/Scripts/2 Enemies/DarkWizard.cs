using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : Enemy
{
    
    
    // Start is called before the first frame update
    void Start()
    {
       
       

    }

    // Update is called once per frame
    void Update()
    {
       /* GoToPlayer()*/;
    }

    //public override void GoToPlayer()
    //{
    //    //if (player != null)
    //    //{

    //    //    Vector3 destination = player.transform.position;
    //    //    Vector3 source = transform.position;
    //    //    Vector3 direction;
    //    //    int scaleX = 1;
    //    //    if (!isTrack)
    //    //    {
    //    //        direction = new Vector3(1, 0, 0);


    //    //    }
    //    //    else
    //    //    {
    //    //        direction = destination - source;
    //    //    }
    //    //    direction.Normalize();
    //    //    transform.position += direction * Time.deltaTime * speed;



    //    //    if (direction.x < 0)
    //    //    {
    //    //        scaleX = -1;
    //    //    }
    //    //    transform.localScale = new Vector3(scaleX, 1, 1);

    //    //    bool isAttacking1 = false;

    //    //    var dx = source.x - destination.x;
    //    //    var dy = source.y - destination.y;




    //    //    if (Mathf.Abs(dx) <= 3 && Mathf.Abs(dy) <= 3)
    //    //    {
    //    //        isAttacking1 = true;
    //    //    }

    //    //    //animator.SetBool("isAttacking", isAttacking1);


    //    //}
    //}

    //public override void Damage(float damageValue)
    //{

    //    if (!isInvincible)
    //    {
    //        StartCoroutine(InvincibleFrames());


    //        enemyHP -= damageValue;
    //        showDamageNumber = true;
    //        damageNumberText.text = damageValue.ToString();



    //        if (enemyHP <= 0)
    //        {
    //            Instantiate(bloodSplash, transform.position, Quaternion.identity);
    //            GameManager.isEnemyDeadSound = true;
    //            Instantiate(crystal, transform.position, Quaternion.identity);



    //            int randomIndex = UnityEngine.Random.Range(0, 101);

    //            if (randomIndex >= 0 && randomIndex <= 5)
    //            {

    //                Vector3 smallHpPot = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z);
    //                Instantiate(smallhealthPot, smallHpPot, Quaternion.identity);
    //            }


    //            if (randomIndex >= 6 && randomIndex <= 9)
    //            {
    //                Vector3 largeHpPot = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, transform.position.z);
    //                Instantiate(largehealthPot, largeHpPot, Quaternion.identity);
    //            }


    //            if (randomIndex >= 10 && randomIndex <= 12)
    //            {
    //                Vector3 magnetPot = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, transform.position.z);
    //                Instantiate(magnet, magnetPot, Quaternion.identity);
    //            }

    //            if (randomIndex >= 13 && randomIndex <= 18)
    //            {
    //                Vector3 goldcoin = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, transform.position.z);
    //                Instantiate(goldCoin, goldcoin, Quaternion.identity);
    //            }
    //            if (randomIndex >= 19 && randomIndex <= 28)
    //            {
    //                Vector3 flameP = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
    //                Instantiate(flame, flameP, Quaternion.identity);
    //            }

    //            if (TitleManager.saveData.isGoldPotionActive == true)
    //            {
    //                if (randomIndex >= 18 && randomIndex <= 19)
    //                {
    //                    Vector3 goldCoinPotion = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
    //                    Instantiate(goldPotion, goldCoinPotion, Quaternion.identity);
    //                }
    //            }


    //            Destroy(gameObject);








    //        }
    //    }

    //}
}
