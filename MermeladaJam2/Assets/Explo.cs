using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explo : MonoBehaviour
{
    public GameObject otro;
    public GameObject ver;
    public AudioSource audio;
    public void DesVer()
    {
        gameObject.SetActive(false);
    }

    public void DesVerOtro()
    {
        otro.SetActive(false);
    }

    public void Ver()
    {
        ver.SetActive(true);
    }

    public void Sonido()
    {
        audio.Play();
    }
}
