using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f; 
    public float rotationSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCuldown = 1;

    private Rigidbody2D rb;
    float horizontalInput;
    float verticalInput;
    private Vector2 mousePosition;
    private bool isDashing = false;
    private float timer = 50;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0) && timer > dashCuldown)
        {
            timer = 0;
            StartCoroutine(Dash());
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.stop == true)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isDashing == true)
        {
            return;
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        rb.velocity = movement * speed;

        Rotate();
    }

    private void Rotate()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f; // Asegúrate de que el cursor esté en el plano Z=0

        // Calcular la dirección hacia el cursor
        Vector3 direction = cursorPosition - transform.position;

        // Rotar el objeto hacia esa dirección
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    IEnumerator Dash()
    {
        isDashing = true;
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        float dashEndTime = Time.time + dashDuration;

        while (Time.time < dashEndTime)
        {
            rb.velocity = direction * dashSpeed;
            yield return null;
        }

        rb.velocity = Vector2.zero;
        isDashing = false;
    }
}