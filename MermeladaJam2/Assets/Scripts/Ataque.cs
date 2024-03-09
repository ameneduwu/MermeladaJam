using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject ataque;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ataque.SetActive(true);
            StartCoroutine(Ocultar());
        }
    }

    IEnumerator Ocultar()
    {
        yield return new WaitForSeconds(1);
        ataque.SetActive(false);
    }
}
