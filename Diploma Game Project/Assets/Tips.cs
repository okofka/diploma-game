using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject tipsUI;
    public int countOfhelp = 1;
    public bool pleaseTrue = false;
    private KeyScript keyScript;

    private void Start()
    {
        keyScript = GameObject.Find("Key").GetComponent<KeyScript>();
        if (tipsUI != null)
        {
            tipsUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (keyScript.isPickedUp == true)
        {
            pleaseTrue = keyScript.isPickedUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (pleaseTrue == true)
            {
                if (tipsUI != null)
                {
                    tipsUI.SetActive(false);
                }
                Debug.Log("2");
            }
            else if (countOfhelp <= 2)
            {
                if (tipsUI != null)
                {
                    StartCoroutine(OffTipsUIAfterDelay(0.8f));
                    countOfhelp++;
                    Debug.Log("1");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tipsUI.SetActive(false);
        }
    }

    private IEnumerator OffTipsUIAfterDelay(float delay)
    {
        tipsUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        tipsUI.SetActive(false);
    }
}
