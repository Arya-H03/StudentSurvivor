using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadArrow : BaseWeapon
{    
    [SerializeField] GameObject spreadObject;
    public bool isSpreadArrowActive = false;
 
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position += transform.up * 5 * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0, 0, 90);
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

            enemy.Damage(damage);
            
            SpreadArrows(level + 8);

            Destroy(gameObject);
            

        }

        if (slaveKnight != null)
        {
            slaveKnight.DamageBoss(damage);
            SpreadArrows(level + 8);

            Destroy(gameObject);
            

        }

    }

    public void SpreadArrows(int numberOfArrows)
    {
       
        float spawnAngle  = 360 / numberOfArrows;
        for (int i = 0; i < numberOfArrows; i++)
        {
            Instantiate(spreadObject, transform.position, Quaternion.Euler(0, 0, i * spawnAngle));
            
        }
        
    }

}
