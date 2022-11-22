using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireHand : MonoBehaviour
{
    GameObject player;
    [SerializeField] float damage;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");

        transform.position = player.transform.position + new Vector3(0,1,0);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.OnDamageBoss(damage);

        }
    }

    public void ActivateHitBox()
    {
        boxCollider2D.enabled = true;
    }

    public void DeActivateHitBox()
    {
        boxCollider2D.enabled = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
