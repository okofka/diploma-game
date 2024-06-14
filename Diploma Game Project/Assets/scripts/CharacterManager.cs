using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CharacterManager : MonoBehaviour
{
    public NPCConversation myConversation;

    private Animator playerAnimator;
    private PlayerMovementScript playerMovementScript;
    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        ConversationManager.OnConversationEnded += HandleConversationEnded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ConversationManager.Instance.StartConversation(myConversation);
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
        // Не забудьте відписатися від події, щоб уникнути витоків пам'яті
        ConversationManager.OnConversationEnded -= HandleConversationEnded;
    }

    private void SetIdleAnimation()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetFloat("Speed", 0); // Зупинити будь-які анімації, що залежать від швидкості
            playerAnimator.SetTrigger("Idle"); // Використовуйте відповідний тригер для анімації Idle
            playerAnimator.speed = 0; // Зупинити анімацію
        }
    }

    private void StopPlayerMovement()
    {
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector2.zero; // Зупинити рух за допомогою фізики
            playerRigidbody.angularVelocity = 0f; // Зупинити обертання
        }
    }

    private void ResumeAnimations()
    {
        if (playerAnimator != null)
        {
            playerAnimator.speed = 1; // Відновити анімацію
        }
    }
}
