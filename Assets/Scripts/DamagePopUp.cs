using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public string damage;
    [SerializeField] TMP_Text damageText;

    private void Awake()
    {
        damageText.text = damage;
    }
    private void Start()
    {
        StartCoroutine(DamagePopUpCoroutine());
    }

    IEnumerator DamagePopUpCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
