using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEBSpawner : BaseWeapon
{
    [SerializeField] GameObject trackingEnergyBall;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrackingSpawnEnergyBallCoroutine());


    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator TrackingSpawnEnergyBallCoroutine()
    {
        while (true)
        {
            for (int i = 0; i <= level; i++)
            {

                player = GameObject.FindGameObjectWithTag("Player");
                float angle = Random.Range(0, 360);
                Instantiate(trackingEnergyBall, player.transform.position + new Vector3 (0,0.5f,0), Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
                
        }



    }

    public override void LevelUp()
    {
        base.LevelUp();
    }
}
