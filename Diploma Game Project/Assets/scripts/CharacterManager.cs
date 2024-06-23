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

    public bool playerInTrigger = false;

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
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
            CursurStartOptions();
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

    public void Update()
    {
        if (playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CursurEndOptions();
                ConversationManager.Instance.StartConversation(myConversation);
                counteR.CheckCountOfCorrectAnswers();
                playerMovementScript.canMove = false;
                SetIdleAnimation();
                StopPlayerMovement();
            }
        }

        if (counteR.counter > 4)
            myConversation = mylastWordsConversation;
    }

    private void CursurStartOptions()
{
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
}

    private void CursurEndOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
