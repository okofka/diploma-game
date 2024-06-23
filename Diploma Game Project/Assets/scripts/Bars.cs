using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{
    public Counter counter;
    public Animator animator;
    public BoxCollider2D boxCollider;
    public bool locked;
    public bool playerInTrigger = false;

    private void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateColliderState();
    }
    private void UpdateColliderState()
    {
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger)
        {
            if (counter.counter > 4)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animator.SetTrigger("Open");
                    StartCoroutine(AllowMovementAfterDelay(0.9f));
                }
            }
        }
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
        }
    }

    private IEnumerator AllowMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        locked = false;
        boxCollider.isTrigger = true;
    }
}
