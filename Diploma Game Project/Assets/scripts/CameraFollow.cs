using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 0f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }/*

    public float FollowSpeed = 2f;
    public float yOffset = 0f;
    public Player target; // ����� ��� ��������� �� ������

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // ��������� ���� ������� ������, � ����������� ������� �� y
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, -10f);
            // ������ ��������� ������ � ���� ������� � ������������� Slerp
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }*/
}
