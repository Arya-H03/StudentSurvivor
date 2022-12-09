using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{
    public Transform targetKnight;
    public Transform targetRanger;
    public Transform targetWitch;
    [SerializeField]  float speed = 100f;
    // Start is called before the first frame update

    [SerializeField] PlayerKnight playerKnight;
    [SerializeField] PlayerRanger playerRanger;
    [SerializeField] PlayerWitch playerWitch;
    Volume volume;
    Vignette vignette;
    ChromaticAberration chromaticAberration;
    void Start()
    {
       

        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        if(TitleManager.saveData.ispostProcessing == false)
        {
            volume.enabled = false;
        }

        if (TitleManager.saveData.ispostProcessing == true)
        {
            volume.enabled = true;
        }
        if (PlayerCharacterManager.isKnight == true)
        {
            float intensity = (1 - playerKnight.GetHPRatio()) * 0.75f;
            vignette.intensity.Override(intensity);
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            float intensity = (1 - playerRanger.GetHPRatio()) * 0.75f;
            vignette.intensity.Override(intensity);
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            float intensity = (1 - playerWitch.GetHPRatio()) * 0.75f;
            vignette.intensity.Override(intensity);
        }

        if (PlayerCharacterManager.isKnight == true)
        {
            if (targetKnight != null)
            {

                float playerX = targetKnight.transform.position.x;
                float playerY = targetKnight.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                transform.position = targetPosition;
            }
        }

        if (PlayerCharacterManager.isRanger == true)
        {
            if (targetRanger != null)
            {

                float playerX = targetRanger.transform.position.x;
                float playerY = targetRanger.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                transform.position = targetPosition;
                
            }
        }

        if (PlayerCharacterManager.isWitch == true)
        {
            if (targetWitch != null)
            {

                float playerX = targetWitch.transform.position.x;
                float playerY = targetWitch.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                transform.position = targetPosition;
            }
        }

    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float currentTime = 0.0f;

        while(currentTime < duration)
        {
            float x = (Random.Range(-1f, 1f) * magnitude) + originalPosition.x;
            float y = (Random.Range(-1f, 1f) * magnitude) + originalPosition.y;
            

            transform.localPosition = new Vector3 (x, y, originalPosition.z);

            currentTime += Time.deltaTime;

            yield return null;
        }

        //transform.localPosition = targetKnight.transform.localPosition;
    }

    public void StartBlur()
    {
        chromaticAberration.intensity.Override(0.75f);
    }

    public void EndBlur()
    {
        chromaticAberration.intensity.Override(0);
    }

    
}
