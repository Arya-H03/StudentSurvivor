using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadArrowSpawner : BaseWeapon
{
    [SerializeField] GameObject spreadDagger;
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
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < level; i++)
            {
                float angle = Random.Range(0, 360);
                Instantiate(spreadDagger, transform.position, Quaternion.Euler(0, 0, angle));
            }

        }



    }

    public override void LevelUp()
    {
        base.LevelUp();
    }
}
