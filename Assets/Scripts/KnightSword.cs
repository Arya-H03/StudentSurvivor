using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSword : BaseWeapon
{
    public bool isSwordActive = false;
    public bool isHitBoxActive = false;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHitBoxActive == true)
        {
            boxCollider2D.enabled = true;
        }

        if (isHitBoxActive == false)
        {
            boxCollider2D.enabled = false;
        }
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
        level++;
        AddDamage(1);
    }
}
