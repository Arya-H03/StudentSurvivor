using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    SpriteRenderer spriteRenderer;
    public static BoxCollider2D boxCollider;

    public static bool isActive;
    


    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(KatanaCoroutine());
    }

    IEnumerator KatanaCoroutine()
    {
        
        //bool isAttacking = false;
        while (true)
        {
            isActive = true;
            boxCollider.enabled = true;
            spriteRenderer.enabled = false;
           
            yield return new WaitForSeconds(2f);

            isActive = false;
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
            
            yield return new WaitForSeconds(1f);
        }

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