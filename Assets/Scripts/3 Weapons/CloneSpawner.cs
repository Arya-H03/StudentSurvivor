using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneSpawner : BaseWeapon
{

    [SerializeField] GameObject clone;
    //[SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawncloneCoroutine());

        //image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject != null)
        //{
        //    image.color = Color.white;
        //}
    }

    IEnumerator SpawncloneCoroutine()
    {
        while (true)
        {
            for (int i = 0; i <= level; i++)
            {



                Instantiate(clone, clone.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(3);



            }



        }
    }

}
