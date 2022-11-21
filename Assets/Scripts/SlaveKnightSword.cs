using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveKnightSword : MonoBehaviour
{
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
        
        if (isHitBoxActive == true)
        {
            boxCollider2D.enabled = true;
           
        }

        if (isHitBoxActive == false)
        {
            boxCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.OnDamageBoss(15);

        }
    }
}
