using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisedSkeletonSpawner : BaseWeapon 
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject raisedSkeleton;
    [SerializeField] float spawnRate = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRaisedSkeleton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRaisedSkeleton()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            for (int i = 0; i < level + 1; i++)
            {
                Vector3 spawnPos = Random.insideUnitCircle.normalized * 2;
                Instantiate(raisedSkeleton, transform.position + spawnPos, Quaternion.identity);
            }
        }
        
        
    }
}
