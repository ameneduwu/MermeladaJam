using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public GameObject dialogo;
    public string[] textoDialogo;
    public bool animacion = false;
    public Animator animator;
    public bool sinEntrada = false;
    public bool animacionSalir = false;
    public bool fundidoNegro = false;
    public Animator fundido;

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
            instancia.sinEntrada = sinEntrada;
            instancia.animacionSalir=animacionSalir;
            instancia.fundidoNegro = fundidoNegro;
            instancia.fundido = fundido;
            Destroy(this);
        }
        if (collision.tag == "Daño")
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
            instancia.animacionSalir = animacionSalir;
            instancia.fundidoNegro = fundidoNegro;
            instancia.fundido = fundido;
            Destroy(this);
        }
    }


}
