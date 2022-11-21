using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] SlaveKnight slaveKnight;
    [SerializeField] FireDemon fireDemon;
    [SerializeField] Image foreground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slaveKnight != null)
        {
            

            float hpRatio = (float)slaveKnight.bossHP / slaveKnight.bossMaxHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

        if (slaveKnight != null)
        {


            float hpRatio = (float)fireDemon.bossHP / fireDemon.bossMaxHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }


    }
}
