using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEBSpawner : BaseWeapon
{
    [SerializeField] GameObject standardEnergyBall;
    [SerializeField] Player player;
    [SerializeField] float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StandardSpawnEnergyBallCoroutine());


    }

    // Update is called once per frame
    void Update()
    {
        
            


        
    }

    IEnumerator StandardSpawnEnergyBallCoroutine()
    {

        while (true)
        {
            Instantiate(standardEnergyBall, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }




    }
}
