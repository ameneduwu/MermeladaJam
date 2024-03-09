using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionAtaque : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            collision.gameObject.GetComponent<Enemigo>().Dead();
            noise.m_AmplitudeGain = 2.0f;
            Invoke("FrequencyDown",0.4f);
        }
    }
    private void FrequencyDown()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
