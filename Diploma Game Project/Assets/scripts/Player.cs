using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level { get; set; }

    public void Start()
    {
        Debug.Log("Player level: " + level);
    }
}
