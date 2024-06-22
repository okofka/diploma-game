using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CharacterManager : MonoBehaviour
{
    public NPCConversation myConversation;
    public NPCConversation mylastWordsConversation;

    private Animator playerAnimator;
    private PlayerMovementScript playerMovementScript;
    private Rigidbody2D playerRigidbody;
    private Counter counteR;

    private void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        counteR = GameObject.Find("Counter").GetComponent<Counter>();
        ConversationManager.OnConversationEnded += HandleConversationEnded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ConversationManager.Instance.StartConversation(myConversation);
            counteR.CheckCountOfCorrectAnswers();
            playerMovementScript.canMove = false;
            SetIdleAnimation();
            StopPlayerMovement();
        }
    }


    private void HandleConversationEnded()
    {
        playerMovementScript.canMove = true;
        ResumeAnimations();
    }

    private void OnDestroy()
    {
        // �� �������� ���������� �� ��䳿, ��� �������� ������ ���'��
        ConversationManager.OnConversationEnded -= HandleConversationEnded;
    }

    private void SetIdleAnimation()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetFloat("Speed", 0); // �������� ����-�� ��������, �� �������� �� ��������
            playerAnimator.SetTrigger("Idle"); // �������������� ��������� ������ ��� �������� Idle
            playerAnimator.speed = 0; // �������� ��������
        }
    }

    private void StopPlayerMovement()
    {
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector2.zero; // �������� ��� �� ��������� ������
            playerRigidbody.angularVelocity = 0f; // �������� ���������
        }
    }

    private void ResumeAnimations()
    {
        if (playerAnimator != null)
        {
            playerAnimator.speed = 1; // ³������� ��������
        }
    }

    public void Update()
    {
        if (counteR.counter > 4)
            myConversation = mylastWordsConversation;
    }
}
