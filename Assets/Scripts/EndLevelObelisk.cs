using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelObelisk : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject newLevelPanel;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       
        //StartCoroutine(SpawnCameraCoroutine());

        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCameraCoroutine()
    {
        if (PlayerCharacterManager.isKnight == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetKnight = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetKnight = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetRanger = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetRanger = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

            Time.timeScale = 1;
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<PlayerCamera>().targetWitch = transform;
            Camera.main.orthographicSize = 4;

            yield return new WaitForSecondsRealtime(4f);

            Camera.main.GetComponent<PlayerCamera>().targetWitch = player.transform;
            Camera.main.orthographicSize = 5;
            yield return new WaitForSecondsRealtime(2f);

            Time.timeScale = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            newLevelPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ActivateObelisk()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        Vector3 spawnPos = Random.insideUnitCircle.normalized * 5;

        transform.position = player.transform.position + spawnPos;
    }

}
