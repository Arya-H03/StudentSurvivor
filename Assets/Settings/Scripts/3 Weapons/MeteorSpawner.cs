using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : BaseWeapon
{
    [SerializeField] GameObject meteor;
    [SerializeField] Player player;
    public PlayerCamera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isFlameFull == true)
        {

            StartCoroutine(SpawnMeteorCoroutine());
            
           
            Player.isFlameFull = false;
            player.playerFlame = 0;
            StartCoroutine(playerCamera.ShakeCamera(1f, 0.1f));

        }
    }
    IEnumerator SpawnMeteorCoroutine()
    {
        
        for(int i = 0; i < 10; i++)
        {
            SpawnMeteor(2);
            yield return new WaitForSeconds(1f);
        }
           
            
        
    }

    void SpawnMeteor(int numberOfMeteor)
    {
        for (int i = 0; i < numberOfMeteor; i++)
        {
            int randomX = Random.Range(-4, 5);
            int randomY =Random.Range(4, 7) ;

            //Vector3 spawnPosition = Random.insideUnitCircle.normalized * 10;
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            //if (!isTrack)
            //{
            //    spawnPosition = new Vector3(-15, dice, 0);


            //}
            if (player != null)
            {
                spawnPosition += player.transform.position;

                GameObject meteorObject = Instantiate(meteor, spawnPosition, Quaternion.identity);
                
            }



        }


    }
}
