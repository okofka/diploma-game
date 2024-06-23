using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public Light2D Light;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.level % 3 == 0 || player.level == 17) // Перевіряємо, чи рівень кратний трьом
        {
            Light.enabled = false;
        }
    }
}
