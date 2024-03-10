using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perro : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.final == true)
        {
            rb.velocity = new Vector2(-1, 0).normalized * 4;

            Vector3 currentRotation = transform.rotation.eulerAngles;

            currentRotation.z = 180f;

            transform.rotation = Quaternion.Euler(currentRotation);

            return;
        }
    }
}
