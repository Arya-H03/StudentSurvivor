using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cultist;
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject fireWorm;
    [SerializeField] GameObject flyingDemon;
    [SerializeField] GameObject hellBeast;
    [SerializeField] GameObject hellHound;
    [SerializeField] GameObject fireDemon;
    [SerializeField] GameObject crow;
    [SerializeField] GameObject bandit;   
    [SerializeField] GameObject slime;
    [SerializeField] GameObject giant;
    [SerializeField] GameObject nightborne;
    [SerializeField] GameObject slaveKnight;
    [SerializeField] AudioSource enemyDeathSound;
    [SerializeField] AudioSource levelUpSound;
    [SerializeField] GameObject playerKnight;
    [SerializeField] GameObject playerRanger;
    [SerializeField] GameObject playerWitch;

    public  int goldGained;
    public  int EXPGained;

    
    public TMP_Text timerText;

    public bool isTracking;
   public static  int sec;
   public static int minutes;
    public static int seconds;
    public static bool isEnemyDeadSound = false;
    public static bool isLevelUpSound = false;
    string a;
    string b;
    protected bool isBossActive = false;



    int spawnCounter = 1;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemyCoroutine());
        //player = GameObject.FindGameObjectWithTag("Player");

        if(PlayerCharacterManager.isKnight == true)
        {
            playerKnight.SetActive(true);
            playerRanger.SetActive(false);
            playerWitch.SetActive(false);
        }
        if(PlayerCharacterManager.isRanger == true)
        {
            playerKnight.SetActive(false);
            playerRanger.SetActive(true);
            playerWitch.SetActive(false);
        }
        if (PlayerCharacterManager.isWitch == true)
        {
            playerKnight.SetActive(false);
            playerRanger.SetActive(false);
            playerWitch.SetActive(true);
        }

        if(TitleManager.saveData.isCrowActive == true)
        {
            crow.SetActive(true); 
        }
    }

    

    private void Update()
    {

       
        if(isEnemyDeadSound == true)
        {
            enemyDeathSound.Play();
            isEnemyDeadSound = false;

        }

        if (isLevelUpSound == true)
        {
            levelUpSound.Play();
            isLevelUpSound = false;

        }



        sec = (int)Time.timeSinceLevelLoad;
            minutes = sec / 60;
            seconds = sec % 60;

            if(seconds < 10)
            {
            a = "0";
            }
            else { a = ""; }

            if (minutes < 10)
            {
            b = "0";
                 }
            else { b = ""; }

        timerText.text = b + minutes.ToString() + ":" + a + seconds.ToString();

        


        if(minutes == 4 && isBossActive == false && TitleManager.CurrentLevel == "Level1")
        {
            SpawnBoss(slaveKnight, 1);
            
            isBossActive = true;
        }
        if(minutes == 4 && isBossActive == false && TitleManager.CurrentLevel == "Level2")
        {
            SpawnBoss(fireDemon, 1);
            
            isBossActive = true;
        }



    }

    private IEnumerator SpawnEnemyCoroutine()
    {

        while (minutes <= 4 && TitleManager.CurrentLevel == "Level1")
        {
            yield return new WaitForSeconds(2f);
            SpawnEnemies(cultist, 3 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(skeleton, 5 * spawnCounter, true);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(skeleton, 10, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 5 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 7 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(slime, 10 * spawnCounter, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 12 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(giant, 3 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(slime, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            //35
            SpawnEnemies(giant, 5 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(bandit, 15, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 20 * spawnCounter, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 20 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(bandit, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(slime, 20 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(cultist, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(slime, 20, false);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(giant, 12 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(skeleton, 15 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            //77
            SpawnEnemies(nightborne, 10 * spawnCounter, true);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(skeleton, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(slime, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(nightborne, 12 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(bandit, 18 * spawnCounter, true);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(giant, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 20 * spawnCounter, true);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(bandit, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(nightborne, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 25 * spawnCounter, true);
            //110
            spawnCounter++;

            isBossActive = false;
        }

        while (minutes <= 4 && TitleManager.CurrentLevel == "Level2")
        {
            yield return new WaitForSeconds(2f);
            SpawnEnemies(cultist, 3 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(skeleton, 5 * spawnCounter, true);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(skeleton, 10, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 5 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 7 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(fireWorm, 10 * spawnCounter, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 12 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(flyingDemon, 3 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(fireWorm, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            //35
            SpawnEnemies(flyingDemon, 5 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(hellBeast, 15, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 20 * spawnCounter, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 20 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(hellBeast, 15 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(fireWorm, 20 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(cultist, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(fireWorm, 20, false);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(flyingDemon, 12 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(skeleton, 15 * spawnCounter, true);
            yield return new WaitForSeconds(5f);
            //77
            SpawnEnemies(hellHound, 10 * spawnCounter, true);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(skeleton, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(cultist, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(fireWorm, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(hellHound, 12 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(hellBeast, 18 * spawnCounter, true);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(flyingDemon, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 20 * spawnCounter, true);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(hellBeast, 20, false);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(hellHound, 20 * spawnCounter, true);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(skeleton, 25 * spawnCounter, true);
            //110
            spawnCounter++;

            isBossActive = false;
        }








    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTrack)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int dice = Random.Range(-9, 10);

            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 10;

            if (!isTrack)
            {
                spawnPosition = new Vector3(-15, dice, 0);

             
            }
            if(PlayerCharacterManager.isKnight == true)
            {
                if (playerKnight != null)
                {
                    spawnPosition += playerKnight.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();

                    enemy.isTrack = isTrack;
                }
            }

            if (PlayerCharacterManager.isRanger == true)
            {
                if (playerRanger != null)
                {
                    spawnPosition += playerRanger.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();

                    enemy.isTrack = isTrack;
                }
            }

            if (PlayerCharacterManager.isWitch == true)
            {
                if (playerWitch != null)
                {
                    spawnPosition += playerWitch.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();

                    enemy.isTrack = isTrack;
                }
            }




        }


    }

    void SpawnBoss(GameObject enemyPrefab, int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {            
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 10;  
            if (PlayerCharacterManager.isKnight == true)
            {
                if (playerKnight != null)
                {
                    spawnPosition += playerKnight.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }
            }

            if (PlayerCharacterManager.isRanger == true)
            {
                if (playerRanger != null)
                {
                    spawnPosition += playerRanger.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }
            }

            if (PlayerCharacterManager.isWitch == true)
            {
                if (playerWitch != null)
                {
                    spawnPosition += playerRanger.transform.position;

                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }
            }


        }
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void OnClickNextLevel() { 
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
}
