using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody2D rb;
    public Animator animator;

    private float horizontalInput, verticalInput; // ���� ��� ���������� �������

    private bool canMove = true; // ����� �� ���

    public void PauseMovement()
    {
        canMove = false;
    }

    public void ResumeMovement()
    {
        canMove = true;
    }

    // ��������� ���� ����� ��� ������ �� ���
    public void UpdateMovement()
    {
        if (canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            rb.velocity = movement * moveSpeed;
        }
    }

    private void Start()
    {
        canMove=false;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AllowMovementAfterDelay(2.8f));
    }

    // �������� ��� ������� �� ��� ���� ����� ��������
    private IEnumerator AllowMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}