using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallSpawner : MonoBehaviour
{
    [SerializeField] GameObject trackingEnergyBall;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnergyBallCoroutine());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnergyBallCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            
            
            Instantiate(trackingEnergyBall, transform.position, Quaternion.identity);
        }



    }
}
