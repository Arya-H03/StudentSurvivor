using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordWallSpawner : BaseWeapon
{
    [SerializeField] GameObject swordWall;
    [SerializeField] Player player;
    [SerializeField] float waitTime = 10;
    [SerializeField] SwordWall swordwall;
    int numberOfSword;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StandardSpawnEnergyBallCoroutine());
          
        
    }

    // Update is called once per frame
    void Update()
    {
        swordwall.MatchLevel(level);
        numberOfSword = base.level;
    }

    IEnumerator StandardSpawnEnergyBallCoroutine()
    {

        while (true)
        {
            SpawnArrow();
            yield return new WaitForSeconds(waitTime);
        }

    }

    public void SpawnArrow()
    {

        float d = 0.4f;
        float c = 0.4f;
        float aHalf = (level - 1) * 0.5f;
        if (level % 2 == 1)
        {
            Instantiate(swordWall, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);

            ;
            for (int i = 0; i < aHalf; i++)
            {
                d = d + 1f;
                Instantiate(swordWall, transform.position + new Vector3(0, d, 0), Quaternion.identity);

            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 1;
                Instantiate(swordWall, transform.position + new Vector3(0, c, 0), Quaternion.identity);


            }
        }


        if (level % 2 == 0)
        {


            ;
            for (int i = 0; i < aHalf; i++)
            {

                Instantiate(swordWall, transform.position + new Vector3(0, d, 0), Quaternion.identity);
                d = d + 1f;

            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 1f;
                Instantiate(swordWall, transform.position + new Vector3(0, c, 0), Quaternion.identity);


            }
        }

    }

    public override void LevelUp()
    {
        base.LevelUp();
    }
}
