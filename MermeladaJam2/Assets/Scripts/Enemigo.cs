using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float speed = 5f;

    public float rotationSpeed = 5;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.instance.player;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.stop == true|| GameManager.instance.stopPeople==true)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize(); 

            Vector2 movement = -direction * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movement);

            // Obtener entrada del teclado
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calcular el desplazamiento en ambos ejes
            movement = new Vector2(horizontalInput, verticalInput) * speed;

            // Aplicar el movimiento al Rigidbody
            rb.velocity = movement;

            // Calcular la rotación hacia la dirección del movimiento
            if (movement != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

                // Rotación gradual
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    public void Dead()
    {
        //animator muerte
        Destroy(gameObject);
    }
}

