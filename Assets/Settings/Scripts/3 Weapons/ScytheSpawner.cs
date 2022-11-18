using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScytheSpawner : BaseWeapon
{
   
    [SerializeField] GameObject scythe;
    [SerializeField] SimpleObjectPool pool;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());

       
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < level; i++)
            {
                //yield return new WaitForSeconds(2f);
                float angle = Random.Range(0, 360);
                var scythe = pool.Get();
                scythe.transform.position = transform.position;
                scythe.transform.rotation = Quaternion.Euler(0, 0, angle);
                scythe.SetActive(true);
               
            }

        }
                 
    }
}
