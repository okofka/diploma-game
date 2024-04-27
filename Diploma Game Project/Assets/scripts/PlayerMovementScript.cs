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
        // ��������� ������� ����� ��� ����
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // ���������� ������� ����
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // ������������ �������� �������
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        speedX = movement.x;
        speedY = movement.y;

        // ������������ �������� ����
        rb.velocity = new Vector2(speedX, speedY);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
