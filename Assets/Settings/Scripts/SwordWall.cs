using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWall : MonoBehaviour
{
    GameObject player;
    int a = 0;
    float direction = 0;
    [SerializeField] float speed = 8f;
    int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        
        StartCoroutine(SwordWallDestroyCoroutine());
    }

    IEnumerator SwordWallDestroyCoroutine()
    {

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
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

            if(direction == 1)
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

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        SlaveKnight slaveKnight = collision.gameObject.GetComponent<SlaveKnight>();
        if (enemy != null)
        {
            enemy.Damage(3 + level);
        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(3 + level);
        }

    }

    public void MatchLevel(int spawnerLevel)
    {
        level = spawnerLevel;
    }
}
