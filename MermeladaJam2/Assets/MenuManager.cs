using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject principal;
    public GameObject creditos;

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit(); ;
    }

    public void GoCreditos()
    {
        creditos.SetActive(true);
        principal.SetActive(false);
    }

    public void GoPrincipal()
    {
        creditos.SetActive(false);
        principal.SetActive(true);
    }
}
