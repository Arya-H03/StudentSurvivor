using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int level = 1;
    public static float damage=1;

    public void LevelUp(float addDamage)
    {
        if (level++ == 0)
        {
            gameObject.SetActive(true);
            AddDamage(addDamage);

        }

        
    }

    public void AddDamage(float addDamage)
    {
        damage = (float)(damage + addDamage);
    }

    //void Update()
    //{
    //    Debug.Log(damage);
    //}
}
