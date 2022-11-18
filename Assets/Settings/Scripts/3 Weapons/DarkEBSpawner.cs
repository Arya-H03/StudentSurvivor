using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEBSpawner : BaseWeapon
{
    [SerializeField] GameObject darkEnergyBall;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDarkEnergyBallCorotine());


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnDarkEnergyBallCorotine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);


            Instantiate(darkEnergyBall, transform.position, Quaternion.identity);
        }



    }
}
