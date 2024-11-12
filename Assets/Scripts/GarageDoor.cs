using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    [Header("�����")]
    public Transform player;
    [Header("��������� ��������������")]
    public float interactionDistance = 3f;
    [Header("���� �������� �����")]
    public float openAngle = -90f;
    [Header("�������� �������� �����")]
    public float rotationSpeed = 2f; 

    private bool isOpen = false;
    private Quaternion closedRotation; 
    private Quaternion openRotation;
    [Header("������������ ���� ������������ �����")]
    public Transform pivot;
    void Start()
    {
        closedRotation = pivot.rotation; 
        openRotation = closedRotation * Quaternion.Euler(openAngle, 0f, 0f);
    }

    void Update()
    {
        OpenDoor();
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;
    }
    void OpenDoor()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);


        Vector3 directionToDoor = transform.position - player.position;
        float angle = Vector3.Angle(player.forward, directionToDoor);


        if (distanceToPlayer <= interactionDistance && angle < 45f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleDoor();
            }
        }

        if (isOpen)
        {
            pivot.rotation = Quaternion.Slerp(pivot.rotation, openRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            pivot.rotation = Quaternion.Slerp(pivot.rotation, closedRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
