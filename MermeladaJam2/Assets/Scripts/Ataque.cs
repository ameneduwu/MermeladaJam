using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject ataque;
    public float tiempo;

    private float timer=50;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.stop == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0)&& timer >= tiempo)
        {
            GameManager.instance.stopPeople = false;
            ataque.SetActive(true);
            StartCoroutine(Ocultar());
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    IEnumerator Ocultar()
    {
        yield return new WaitForSeconds(0.3f);
        ataque.SetActive(false);
    }
}
