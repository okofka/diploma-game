using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 0f;
    public Transform target;
    private CharacterManager characterManager;
    private Bars bars;
    private float initialYOffset;

    private void Start()
    {
        GameObject characterTableObject = GameObject.Find("Character-table");
        if (characterTableObject != null)
        {
            characterManager = characterTableObject.GetComponent<CharacterManager>();
        }
        GameObject barsObject = GameObject.Find("bars");
        if (barsObject != null)
        {
            bars = barsObject.GetComponent<Bars>();
        }
        initialYOffset = yOffset; // «бер≥гаЇмо початкове значенн€ yOffset
    }

    // Update is called once per frame
    void Update()
    {
        if (characterManager == null)
        {
            NormalCameraFollow();
        }
        else if (characterManager != null && characterManager.playerInTrigger)
        {
            FollowWithOffsetForTeacher();
        }
        else if (bars != null && bars.playerInTrigger) {
            FollowWithOffsetForBars();
        }
        else {
            NormalCameraFollow();
        }
    }

    private void NormalCameraFollow()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + initialYOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void FollowWithOffsetForTeacher()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + initialYOffset +1f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void FollowWithOffsetForBars()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + initialYOffset + 0.5f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
    /*
    public float FollowSpeed = 2f;
    public float yOffset = 0f;
    public Player target; // «м≥нна дл€ посиланн€ на гравц€

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // ¬изначаЇмо нову позиц≥ю камери, з урахуванн€м зм≥щенн€ по y
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, -10f);
            // ѕлавно перем≥щуЇмо камеру в нову позиц≥ю з використанн€м Slerp
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }*/
}
