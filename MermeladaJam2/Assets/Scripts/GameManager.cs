using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Transform player;
    public bool stop = false;
    public bool stopPeople = true;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
