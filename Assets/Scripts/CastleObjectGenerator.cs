using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject barrelG1;
    [SerializeField] GameObject barrelG2;
    [SerializeField] GameObject barrelG3;
    [SerializeField] GameObject boneGroupG1;
    [SerializeField] GameObject boneGroupG2;
    [SerializeField] GameObject boneGroupG3;
    [SerializeField] GameObject greenCarpetG;
    [SerializeField] GameObject redCarpetG;
    [SerializeField] GameObject yellowCarpetG;
    [SerializeField] GameObject greenPotGroup;
    [SerializeField] GameObject redPotGroup;
    [SerializeField] GameObject rockGroup1;
    [SerializeField] GameObject rockGroup2;
    [SerializeField] GameObject rockGroup3;
    [SerializeField] GameObject rockGroup4;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = UnityEngine.Random.Range(0, 150);
        Vector3 spawnPos = transform.position + Random.insideUnitSphere.normalized * 1;
        if (randomIndex >= 0 && randomIndex <= 9)
        {
            Instantiate(barrelG1, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 10 && randomIndex <= 19)
        {
            Instantiate(barrelG2, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 20 && randomIndex <= 29)
        {
            Instantiate(barrelG3, spawnPos, Quaternion.identity);
        }

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
            Instantiate(rockGroup1, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 100 && randomIndex <= 109)
        {
            Instantiate(rockGroup2, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 110 && randomIndex <= 119)
        {
            Instantiate(rockGroup3, spawnPos, Quaternion.identity);
        }
        if (randomIndex >= 120 && randomIndex <= 129)
        {
            Instantiate(rockGroup4, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 130 && randomIndex <= 139)
        {
            Instantiate(redPotGroup, spawnPos, Quaternion.identity);
        }

        if (randomIndex >= 140 && randomIndex <= 149)
        {
            Instantiate(greenPotGroup, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
