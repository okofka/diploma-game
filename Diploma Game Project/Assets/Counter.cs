using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter = 0;
    private int previousCounter = 0;

    public void AddOne()
    {
        counter++;
    }

    private void Update()
    {
        if (counter > previousCounter)
        {
            Debug.Log("Counter increased: " + counter);
            previousCounter = counter;
        }

        if (counter == 3)
        {
            GameObject keyObject = GameObject.FindGameObjectWithTag("Key");
            if (keyObject != null)
            {
                Collider2D keyCollider = keyObject.GetComponent<Collider2D>();
                if (keyCollider != null)
                {
                    keyCollider.enabled = true;
                }
            }
        }
    }

    private void Start()
    {
        GameObject keyObject = GameObject.FindGameObjectWithTag("Key");
        if (keyObject != null)
        {
            if (counter == 0)
            {
                Collider2D keyCollider = keyObject.GetComponent<Collider2D>();
                if (keyCollider != null)
                {
                    keyCollider.enabled = false;
                }
            }
        }
        else
        {
            Debug.LogError("Key object not found.");
        }
    }
}
