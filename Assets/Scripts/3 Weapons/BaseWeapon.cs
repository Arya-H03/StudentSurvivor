using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int level = 1;
    public float damage = 1;

    public virtual void LevelUp()
    {
        if (level++ == 0)
        {
            gameObject.SetActive(true);
            
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
