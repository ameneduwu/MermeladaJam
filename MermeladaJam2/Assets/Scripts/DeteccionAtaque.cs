using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionAtaque : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject efect;
    public AudioClip uno, dos;
    private CinemachineBasicMultiChannelPerlin noise;
    public AudioSource auso;

    private void Start()
    {
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            if (Random.Range(0,2)==1)
            {
                auso.PlayOneShot(uno);
            }
            else
            {
                auso.PlayOneShot(dos);
            }
            GameManager.instance.enemigosDerrotados++;
            Instantiate(efect, collision.ClosestPoint(transform.position),Quaternion.identity);
            collision.gameObject.GetComponent<Enemigo>().Dead();
            noise.m_AmplitudeGain = 3.0f;
            Invoke("FrequencyDown",0.25f);
        }
    }
    private void FrequencyDown()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
