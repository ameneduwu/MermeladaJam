using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionAtaque : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            collision.gameObject.GetComponent<Enemigo>().Dead();
        }
    }
}
