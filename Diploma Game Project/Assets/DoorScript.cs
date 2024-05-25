using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public bool locked;
    public BoxCollider2D boxCollider;
    private bool keyInTrigger;

    void Start()
    {
        locked = true;
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
                locked = false;
                boxCollider.isTrigger = true;
                GameObject keyObject = GameObject.FindGameObjectWithTag("Key");
                Destroy(keyObject);
                //UpdateCoordinateZ();
            }
            else
            {
                Debug.Log("LyaLyaLya");
            }
        }
    }
}
