using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerSpawner : BaseWeapon
{
    [SerializeField] GameObject dagger;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDaggerCoroutine());


    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator SpawnDaggerCoroutine()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(2f);
            SpawnDagger(level);


        }



    }

    private void SpawnDagger(int level)
    {
        int numberOfDaggers = 6 + level;
        float spawnAngle = 360 / numberOfDaggers;
        for(int i = 0; i < numberOfDaggers; i++)
        {
            Instantiate(dagger, transform.position, Quaternion.Euler(0, 0, i * spawnAngle));
        }
        
    }

    public override void LevelUp()
    {
        base.LevelUp();
    }
}
