using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSpear : BaseWeapon
{
    // Start is called before the first frame update
    [SerializeField] int spearHp;
    void Start()
    {
        StartCoroutine(SpearCoroutine());


    }

    IEnumerator SpearCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position += transform.up * 8 * Time.deltaTime;
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(damage);

            if (spearHp <= 0)
            {
                
                Destroy(gameObject);
            }
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
            if (spearHp <= 0)
            {

                Destroy(gameObject);
            }
        }

    }

    public override void LevelUp()
    {
        AddDamage(1);
        level++;
    }
}
