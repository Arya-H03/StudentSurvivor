using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crow : MonoBehaviour
{
    [SerializeField] GameObject playerKnight;
    [SerializeField] GameObject playerRanger;
    [SerializeField] GameObject playerWitch;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(0,0,0);
       
        FindGoldCoins();
        if(FindGoldCoins() != null)
        {
            targetPosition = FindGoldCoins().transform.position;          
        }

        if (FindGoldCoins() == null)
        {

            if (PlayerCharacterManager.isKnight == true && playerKnight!=null)
            {
                targetPosition = playerKnight.transform.position + new Vector3(0,1,0);
            }
            if (PlayerCharacterManager.isRanger == true && playerRanger != null)
            {
                targetPosition = playerRanger.transform.position + new Vector3(0, 1, 0);
            }
            if (PlayerCharacterManager.isWitch == true && playerWitch != null)
            {
                targetPosition = playerWitch.transform.position + new Vector3(0, 1, 0);
            }
        }    
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.5f * Time.deltaTime);
        int scaleX = 1;
        if (targetPosition.x < 0)
        {
            scaleX = -1;
        }

        if (targetPosition.x >= 0)
        {
            scaleX = 1;
        }
        transform.localScale = new Vector3(-scaleX, 1, 1);

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
