using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource aus;
    public AudioClip menu,accion,chil;
    public bool bajarmusica = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            aus.volume = 0.3f;
            aus.Stop(); 
        }
        else
        {
            if (level==1)
            {
                aus.clip = accion;
                aus.Play();
            }
            else
            {
                if (level == 5)
                {
                    aus.clip = chil;
                    aus.Play();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (bajarmusica==true)
        {
            if (aus.volume>0)
            {
                aus.volume = aus.volume - 0.2f * Time.fixedDeltaTime;
            }
            else { bajarmusica = false; }

            
        }
    }
}
