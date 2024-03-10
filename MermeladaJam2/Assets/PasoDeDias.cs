using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasoDeDias : MonoBehaviour
{
    public void DesStop()
    {
        GameManager.instance.stop = false;
    }
}
