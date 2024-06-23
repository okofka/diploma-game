using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ender : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        CursurEndOptions();
        animator = GetComponent<Animator>();
        StartCoroutine(AllowMovementAfterDelay(135));
    }
    private IEnumerator AllowMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    private void CursurEndOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
