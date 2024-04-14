using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 0.03f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    Vector2 playerPosition;
    Vector2 position = new Vector2(-0f, -5f);
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerPosition = transform.position;
            playerPosition.x += 1; // «б≥льшуЇмо X координату на 1
            playerPosition = Camera.main.ScreenToWorldPoint(playerPosition);
            position = Vector2.Lerp(transform.position, playerPosition, moveSpeed);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
