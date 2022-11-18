using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [SerializeField] GameObject goblin;
    [SerializeField] GameObject player;
    GameObject goldCoin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGoblinCoroutine());
        goldCoin = GameObject.FindGameObjectWithTag("GoldCoin");
    }

    // Update is called once per frame
    void Update()
    {
        goldCoin = GameObject.FindGameObjectWithTag("GoldCoin");
    }

    IEnumerator SpawnGoblinCoroutine()
    {
        if(goldCoin != null)
        {
            while (true)
            {

                Instantiate(goblin, player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(5f);
                

            }
        }
        



    }
}
