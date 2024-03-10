using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasoDeDias : MonoBehaviour
{
    public GameObject dialogo;
    public string[] textoDialogo;
    public bool animacion = false;
    public Animator animator;
    public bool sinEntrada = false;
    public void Dialogo()
    {
        
            Dialogo instancia = Instantiate(dialogo).GetComponentInChildren<Dialogo>();
            instancia.lines = textoDialogo;
            GameManager.instance.stop = true;
            if (animacion == true)
            {
                instancia.animacion = true;
                instancia.animator = animator;
            }
            instancia.sinEntrada = sinEntrada;
            Destroy(this);
        
    }

    public void DesStop()
    {
        GameManager.instance.stop = false;
    }
}
