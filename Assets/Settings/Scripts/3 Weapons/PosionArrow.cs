using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionArrow : BaseWeapon
{
    [SerializeField] int arrowHp = 10;
    public static int numberOfTicks = 3;
    public static float dotDamage = 0.5f; 
    int a = 0;
    float direction = 0;
    GameObject player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float scaleX;
            scaleX = player.transform.localScale.x;
            if (a < 1)
            {
                a = 1;
                direction = -scaleX;
            }

            transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * 10f;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(0.25f);
            arrowHp--;
            if (arrowHp <= 0)
            {
                animator.SetBool("isHit", true);
                Destroy(gameObject);
            }

        }

        if (slaveKnight != null)
        {
            enemy.Damage(0.25f);
            arrowHp--;
            if (arrowHp <= 0)
            {
                //Destroy(gameObject);
            }

        }

    }

    
}
