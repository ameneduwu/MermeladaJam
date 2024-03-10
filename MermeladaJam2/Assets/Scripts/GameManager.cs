using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Transform player;
    public bool stop = false;
    public bool stopPeople = true;
    public bool final = false;
    public int enemigosDerrotados = 0;
    public GameObject[] enemigos;


    public GameObject dialogo;
    public string[] textoDialogo;
    public bool animacion = false;
    public Animator animator;
    public bool sinEntrada = false;
    public bool animacionSalir = false;
    public bool fundidoNegro = false;
    public Animator fundido;

    private bool primerVez = false;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (enemigosDerrotados >= enemigos.Length&& primerVez==false)
        {
            primerVez = true;
            Evento();
        }
    }

    public void Evento()
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
