using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    float speedX, speedY;

    public Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        // Отримання вхідних даних для руху
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Визначення вектора руху
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Встановлення швидкості анімації
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        speedX = movement.x;
        speedY = movement.y;

        // Встановлення швидкості руху
        rb.velocity = new Vector2(speedX, speedY);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
