using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public GameObject dialogo;
    public string[] textoDialogo;
    public bool animacion = false;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Dialogo instancia = Instantiate(dialogo).GetComponentInChildren<Dialogo>();
            instancia.lines = textoDialogo;
            GameManager.instance.stop=true;
            if (animacion==true)
            {
                instancia.animacion = true;
                instancia.animator = animator;
            }
            Destroy(this);
        }
    }


}
