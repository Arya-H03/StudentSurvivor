using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class Axe : BaseWeapon
{
    GameObject player;
    public float speed;

    
    private void Start()
    {

        speed = 150f;
    }

    //void RotateByDegrees()
    //{
    //    Vector3 rotationToAdd = new Vector3(0, 0, 0.3f);
    //    transform.Rotate(rotationToAdd);
    //}

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (TitleManager.saveData.isAxeUpgradeActive == true)
        {
            speed = 250f;
        }
        float scaleX;
        scaleX = player.transform.localScale.x;
        if(scaleX < 0)
        {
            scaleX = -scaleX;
        }
        transform.localScale = new Vector3(-scaleX, 1, 1);
        transform.RotateAround(player.transform.position,new Vector3(0,0,1), speed * Time.deltaTime);
        //RotateByDegrees();
        
        
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
}
