using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDead : MonoBehaviour
{
    public delegate void Contact();
    public event Contact OnContact;
    public Perro cabra;

    private void Start()
    {
        OnContact += cabra.ActiveMove;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Daño")
        {
            OnContact();
        }
    }

}
