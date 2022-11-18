using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        FindGoldCoins();
        
        transform.position = Vector3.MoveTowards(transform.position, FindGoldCoins().transform.position, 2 * Time.unscaledDeltaTime);
    }

    private GoldCoin FindGoldCoins()
    {
        float distanceToClosestGoldCoin = Mathf.Infinity;
        GoldCoin closestGoldCoin = null;
        GoldCoin[] goldCoins = GameObject.FindObjectsOfType<GoldCoin>();

       foreach(GoldCoin currentGoldCoin in goldCoins)
        {
            float distanceToGoldCoin = (currentGoldCoin.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToGoldCoin < distanceToClosestGoldCoin)
            {
                distanceToClosestGoldCoin = distanceToGoldCoin;
                closestGoldCoin = currentGoldCoin;
            }
            
        }
        
        return closestGoldCoin;
        
        //    for (int i = 0; i < goldCoins.Length; i++)
        //    {
        //    //while (goldCoins[i] != null)
        //    //{
        //    if(goldCoins[i] != null)
        //    {
        //        transform.position += goldCoins[i].transform.position * Time.deltaTime * 5;

        //    }
        //    //}

        //}



    }
}
