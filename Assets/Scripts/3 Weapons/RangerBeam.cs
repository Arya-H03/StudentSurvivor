using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerBeam : BaseWeapon
{
    public bool isBeamActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
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

    public override void LevelUp()
    {
        AddDamage(1);
        level++;
    }
}
