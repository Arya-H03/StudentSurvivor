using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource enemyDeathSource;
    public static bool isEnemyDeadSound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyDeadSound == true)
        {
            enemyDeathSource.Play();
        }
    }

    public void EnemyDeathSFX()
    {
        
       
    }
}
