using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        base.Update();
        if (enemyHP <= 0)
        {
            AfterDeath.slimeKilled++;
        }
    }

    protected override void KillEnemy()
    {
        base.KillEnemy();
        if (enemyHP <= 0)
        {

            AfterDeath.slimeKilled++;
        }
    }
}
