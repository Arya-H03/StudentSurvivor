using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerRanger : Player
{
    [SerializeField] GameObject defaultArrow;
    [SerializeField] GameObject beam;
    [SerializeField] GameObject spreadArrow;
    [SerializeField] GameObject rainOfArrow;
    [SerializeField] RainOfArrow rainOfArrows;
    [SerializeField] RangerBeam rangerBeams;
    [SerializeField] SpreadArrow spreadArrows;
    [SerializeField] RangerArrow currentArrow; 
    
    int numberOfArrow = 1;
    bool isSpreadArrow = false;
    
    // Start is called before the first frame update
    protected override void Start()
    {
       
            base.Start();
            StartCoroutine(RangerShoots());
            StartCoroutine(SpecialAttack());
            StartCoroutine(RainOfArrows());
            StartCoroutine(SpreadArrows());
        



    }

    // Update is called once per frame
    protected override void Update()
    {
       
            base.Update();
        
        
    }

    public void SpawnArrow()
    {
  
        float d = 0.4f;
        float c = 0.4f;
        float aHalf = (numberOfArrow - 1) * 0.5f;
        if (numberOfArrow % 2 == 1)
        {
            Instantiate(defaultArrow, transform.position + new Vector3(0, 0.4f, 0), Quaternion.Euler(0, 0, 0));
            //currentArrow.SetSpawnAngle(0);
        
            for (int i = 0; i < aHalf; i++)
            {
                d = d + 0.1f;
                Instantiate(defaultArrow, transform.position + new Vector3(0, d, 0), Quaternion.Euler(0, 0, 0));
                //currentArrow.SetSpawnAngle(d);

            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 0.1f;
                Instantiate(defaultArrow, transform.position + new Vector3(0, c, 0), Quaternion.Euler(0, 0, 0));
                //currentArrow.SetSpawnAngle(c);


            }
        }

        
        if (numberOfArrow % 2 == 0)
        {
            

            ;
            for (int i = 0; i < aHalf; i++)
            {
               
                Instantiate(defaultArrow, transform.position + new Vector3(0, d, 0), Quaternion.Euler(0, 0, 0));
                d = d + 0.1f;
                //currentArrow.SetSpawnAngle(d);
            }

            for (int i = 0; i < aHalf; i++)
            {
                c = c - 0.1f;
                Instantiate(defaultArrow, transform.position + new Vector3(0, d, 0), Quaternion.Euler(0, 0, 0));
                //currentArrow.SetSpawnAngle(c);

            }
        }

    }
    public void SpawnBeam()
    {
        if(transform.localScale.x >= 0)
        {
            Instantiate(beam, transform.position + new Vector3(-5.25f, 0.25f, 0), Quaternion.identity);
        }
        if(transform.localScale.x < 0)
        {
            Instantiate(beam, transform.position + new Vector3(+5.25f, 0.25f, 0), Quaternion.identity);
        }
        
    }

    //public void SpawnSpreadArrow()
    //{
    //    if(isSpreadArrow == true)
    //    {
    //        float angle = Random.Range(0, 360);
    //        Instantiate(spreadArrow, transform.position,Quaternion.Euler(0,0, angle));
    //    }
    //}

    public void SpawnRainOfArrow()
    {
        Vector3 spawnPos = Random.insideUnitSphere.normalized * 2;
        Instantiate(rainOfArrow, transform.position + spawnPos , Quaternion.identity);
    }
    IEnumerator RangerShoots()
    {
          yield return new WaitForSeconds(2);
            while (true)
            {

                animator.SetBool("isShooting", true);
                yield return new WaitForSeconds(1);
                animator.SetBool("isShooting", false);
                yield return new WaitForSeconds(0.5f);

            }
          
        
    }

    IEnumerator SpecialAttack()
    {

       
        while (true)
                {
                
                yield return new WaitForSeconds(4);
                if (rangerBeams.isBeamActive == true)
                    {
                        animator.SetTrigger("SpecialAttack");
                        //yield return new WaitForSeconds(10);
                    }
                }
            
       
       
    }

    IEnumerator RainOfArrows()
    {
    


        while (true)
        {
           
            yield return new WaitForSeconds(7);
            if (rainOfArrows.isRainOfArrowActive == true)
            {

                animator.SetTrigger("RainOfArrow");
                //yield return new WaitForSeconds(10);
            }

        }
           

    }

    IEnumerator SpreadArrows()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if (spreadArrows.isSpreadArrowActive == true)
            {
                isSpreadArrow = true;
                yield return new WaitForSeconds(5);
                isSpreadArrow = true;
            }
            
        }
    }
    public void ActivateRainOfArrow()
    {
            
            rainOfArrows.isRainOfArrowActive = true;
    }
    public void ActivateRangerBeam()
    {
      
        rangerBeams.isBeamActive = true;
    }

    public void IncreaseNumberOfArrow()
    {
        numberOfArrow++;
    }

    public void ActivateSpreadArrow()
    {
        spreadArrows.isSpreadArrowActive = true;
    }

}
