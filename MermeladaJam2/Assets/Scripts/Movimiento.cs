using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Animator animator;
    private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0) && timer > dashCuldown&& GameManager.instance.stop == false)
        {
            timer = 0;
            if (audioSource!=null)
            {
                audioSource.Play();
            }
            StartCoroutine(Dash());
            animator.SetBool("Caminar", false);
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.final==true)
        {
            rb.velocity = new Vector2(0, 1).normalized * speed;

            Vector3 currentRotation = transform.rotation.eulerAngles;

            currentRotation.z = 90f;

            transform.rotation = Quaternion.Euler(currentRotation);
            animator.SetBool("Caminar", true);
            return;
        }

        if (GameManager.instance.stop == true)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("Caminar", false);
            return;
        }
        if (isDashing == true)
        {
            return;
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        rb.velocity = movement * speed;

        if (movement!=Vector2.zero)
        {
            animator.SetBool("Caminar", true);
        }
        else
        {
            animator.SetBool("Caminar", false);
        }

        Rotate();
    }

    private void Rotate()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;

        Vector3 direction = cursorPosition - transform.position;

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