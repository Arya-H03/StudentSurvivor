using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveKnightSwordWall : MonoBehaviour
{
    int a = 0;
    float direction = 0;
    GameObject SlaveKnight;
    [SerializeField] float speed = 8f;
   
    void Start()
    {
        StartCoroutine(SwordWallDestroyCoroutine());
        SlaveKnight = GameObject.FindGameObjectWithTag("SlaveKnight");
    }

    IEnumerator SwordWallDestroyCoroutine()
    {

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {

        if (SlaveKnight != null)
        {

            float scaleX;
            scaleX = SlaveKnight.transform.localScale.x;
            
            if (a < 1)
            {
                a = 1;
                direction =scaleX;
                

            }

            if (direction == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (direction == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            
            transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * speed;
            transform.localScale = new Vector3(direction, 1, 1);

        }

        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player)
        {
            player.OnDamageBoss(5);
        }

     

    }

}
