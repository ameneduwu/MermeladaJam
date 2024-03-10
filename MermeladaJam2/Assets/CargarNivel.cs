using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    public void Siguiente()
    {
        SceneManager.LoadScene(1);
    }
}
