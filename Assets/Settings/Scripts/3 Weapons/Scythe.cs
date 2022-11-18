using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : BaseWeapon
{
    
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(ScytheCoroutine());


    }

    IEnumerator ScytheCoroutine()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 0, 0.3f);
        transform.Rotate(rotationToAdd);
    }
    // Update is called once per frame
    void Update()
    {
        RotateByDegrees();
        transform.position += transform.up  * 5 * Time.deltaTime;
        
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
