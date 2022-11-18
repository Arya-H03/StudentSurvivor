using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSpearSpawner : BaseWeapon
{
    [SerializeField] GameObject spear;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSpearCoroutine());


    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator SpawnSpearCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < level; i++)
            {              
                float angle = Random.Range(0, 360);
                Instantiate(spear, transform.position, Quaternion.Euler(0, 0, angle));
            }

        }



    }
}
