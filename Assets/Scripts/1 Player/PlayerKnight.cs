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
    }

    IEnumerator PlayerAttacks()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(2.5f);
        }
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
