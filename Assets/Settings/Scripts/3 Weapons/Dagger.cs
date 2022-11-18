using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : BaseWeapon
{
    [SerializeField] int DaggerHp = 3;
    void Start()
    {
        


    }

   

    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 0, 0.3f);
        transform.Rotate(rotationToAdd);
    }
    // Update is called once per frame
    void Update()
    {
        //RotateByDegrees();
        transform.position += transform.up * 7 * Time.deltaTime;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(damage);
            enemy.StartCoroutine(enemy.Slow());
            DaggerHp--;
            if (DaggerHp <= 0)
            {
                Destroy(gameObject);
            }
           
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
            DaggerHp--;
            if (DaggerHp <= 0)
            {
                Destroy(gameObject);
            }
           
        }

    }
}
