using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnight : Player
{
    // Start is called before the first frame update
    [SerializeField] KnightSword knightSword;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(PlayerAttacks());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attachRange, enemyLayer);
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    enemy.GetComponent<Enemy>().Damage(swordDamage);
        //}
    }

    IEnumerator PlayerAttacks()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(2.5f);
        }
        //Attack();
        //isAttacking = false;       
        //isAttacking = true;
    }

    public void SetSwordHitBoxActive()
    {
        knightSword.isHitBoxActive = true;
    }
    public void SetSwordHitBoxDeActive()
    {
        knightSword.isHitBoxActive = false;
    }
}
