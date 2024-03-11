using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Perro : MonoBehaviour
{
    bool move = false;
    Rigidbody2D rb;
    public AudioSource audioSource;
    public bool cabra;
    private bool firts = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.final == true || move == true)
        {
            if (cabra == true)
            {
                rb.velocity = new Vector2(0, -1).normalized * 4;
            }
            else
            {
                rb.velocity = new Vector2(0, 1).normalized * 4;
            }
            if (firts == false)
            {
                firts = true;
                audioSource.Play();
            }

            return;
        }
    }

    public void ActiveMove()
    {
        move = true;
    }
}
