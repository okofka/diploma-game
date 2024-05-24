using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {   
            /*
            Vector3 offset = new Vector3(0, 1, 0); */
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position/* + offset*/, ref vel, smoothTime);


            /* шоб ховалось за персонажа
            Vector3 targetPosition = player.transform.position;
            targetPosition.z = 1; // Встановлюємо z координату гравця рівною 1

            Vector3 currentPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref vel, smoothTime);
            currentPosition.z = 1; // Встановлюємо z координату ключа рівною 1

            transform.position = currentPosition;*/
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        { 
            isPickedUp = true;
        }
    }
}
