using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ObjectGenerator : MonoBehaviour
{
    
    [SerializeField] GameObject boneGroupG1;
    [SerializeField] GameObject boneGroupG2;
    [SerializeField] GameObject boneGroupG3;
    [SerializeField] GameObject boneGroupG4;
    [SerializeField] GameObject boneGroupG5;
    [SerializeField] GameObject campfire;
    [SerializeField] GameObject graveStone1;
    [SerializeField] GameObject graveStone2;
    [SerializeField] GameObject statueGroup;
    [SerializeField] GameObject pillarGroup;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = UnityEngine.Random.Range(0, 150);
        Vector3 spawnPos = transform.position + Random.insideUnitSphere.normalized * 1;
        //if (randomIndex >= 0 && randomIndex <= 9)
        //{
        //    Instantiate(barrelG1, spawnPos, Quaternion.identity);
        //}

        //if (randomIndex >= 10 && randomIndex <= 19)
        //{
        //    Instantiate(barrelG2, spawnPos, Quaternion.identity);
        //}

        //if (randomIndex >= 20 && randomIndex <= 29)
        //{
        //    Instantiate(barrelG3, spawnPos, Quaternion.identity);
        //}

        if (randomIndex >= 30 && randomIndex <= 39)
        {
            Instantiate(boneGroupG1, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 40 && randomIndex <= 49)
        {
            Instantiate(boneGroupG2, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 50 && randomIndex <= 59)
        {
            Instantiate(boneGroupG3, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 60 && randomIndex <= 69)
        {
            Instantiate(boneGroupG4, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 70 && randomIndex <= 79)
        {
            Instantiate(boneGroupG5, spawnPos, Quaternion.identity);
        }

        //if (randomIndex >= 60 && randomIndex <= 69)
        //{
        //    Instantiate(greenCarpetG, spawnPos, Quaternion.identity);
        //}

        //if (randomIndex >= 70 && randomIndex <= 79)
        //{
        //    Instantiate(redCarpetG, spawnPos, Quaternion.identity);
        //}

        //if (randomIndex >= 80 && randomIndex <= 89)
        //{
        //    Instantiate(yellowCarpetG, spawnPos, Quaternion.identity);
        //}

        if (randomIndex >= 90 && randomIndex <= 99)
        {
            Instantiate(campfire, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 100 && randomIndex <= 109)
        {
            Instantiate(graveStone1, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 110 && randomIndex <= 119)
        {
            Instantiate(graveStone2, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 120 && randomIndex <= 129)
        {
            Instantiate(statueGroup, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 130 && randomIndex <= 139)
        {
            Instantiate(pillarGroup, spawnPos, Quaternion.identity);
        }

        //if (randomIndex >= 140 && randomIndex <= 149)
        //{
        //    Instantiate(greenPotGroup, spawnPos, Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
