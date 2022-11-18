using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : BaseWeapon
{
    GameObject player;
   
    protected bool isEnding;
    protected bool isDestinationSet = false;
    protected bool isAtDestination = false;

    Vector3 des;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        StartCoroutine(DestroyMeteorCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();

        Vector3 source = transform.position;
        Vector3 destination = player.transform.position;
        Vector3 direction = destination - source;
       
        int scaleX = 0;
        direction.Normalize();

        if (direction.x < 0)
        {
            scaleX = -1;
        }

        
        transform.position += direction * Time.deltaTime * 3f;


        if (direction.x < 0)
        {
            scaleX = -1;
        }
        transform.localScale = new Vector3(scaleX, 1, 1);

        

        //IsAtDestination(destination, source);
        //if (isAtDestination == true)
        //{
        //    Debug.Log("Hello");
        //    isEnding = true;
        //    animator.SetBool("isEnding", isEnding);
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(25f);
        }
    }

    private void SetDestination()
    {
        if (isDestinationSet == false)
        {
            Vector3 destination = Random.insideUnitCircle.normalized * 5;
            //int randomX = Random.Range(-2, 2);
            //int randomY = Random.Range(-4, 0);
            //destination =  new Vector3(randomX, randomY, 0);

            destination += player.transform.position;
            isDestinationSet = true;

            des = destination;
        }


    }

    private void IsAtDestination(Vector3 destination, Vector3 currentLocation)
    {
        if(destination == currentLocation)
        {
            isAtDestination = true;
        }
    }

    IEnumerator DestroyMeteorCoroutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
