using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneSpawner : BaseWeapon
{

    [SerializeField] GameObject clone;
    GameObject player;
    //[SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawncloneCoroutine());
        player = GameObject.FindGameObjectWithTag("Player");
 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawncloneCoroutine()
    {
        while (true)
        {
            for (int i = 0; i <= level; i++)
            {


                yield return new WaitForSeconds(1);
                Instantiate(clone, player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(8);



            }



        }
    }

    public override void LevelUp()
    {
        base.LevelUp();
    }

}
