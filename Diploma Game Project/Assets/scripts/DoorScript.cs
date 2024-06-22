using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorScript : MonoBehaviour
{
    public bool locked;
    public BoxCollider2D boxCollider;
    private bool keyInTrigger;
    public Animator animator;

    void Start()
    {
        locked = true;
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateColliderState();
        animator = GetComponent<Animator>();
    }
    
    private void UpdateColliderState()
    {
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }
    }
    /*
    private void UpdateCoordinateZ()
    {
        Vector3 position = transform.position;
        position.z = boxCollider.isTrigger ? 0 : 2;
        transform.position = position;
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            keyInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            keyInTrigger = false;
        }
    }

    private void Update()
    {
        if (keyInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("Open");
                boxCollider.isTrigger = false;
                GameObject keyObject = GameObject.FindGameObjectWithTag("Key");
                Destroy(keyObject);
                StartCoroutine(AllowMovementAfterDelay(0.9f));
                //UpdateCoordinateZ();
            }
        }
    }

       
// Корутина для дозволу на рух після певної затримки
    private IEnumerator AllowMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        locked = false;
        boxCollider.isTrigger = true;
    }
}
