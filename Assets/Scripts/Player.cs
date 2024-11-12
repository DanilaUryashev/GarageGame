using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Чувствительность мыши")]
    public float mouseSensitivity = 100f;
    [Header("Тело игрока")]
    public Transform playerBody;
    [Header("Скорость перемещения")]
    public float moveSpeed = 5f;

    private float xRotation = 0f; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        movePlayer();
        lookPlayer();
    }
    void lookPlayer()
    {
 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        playerBody.Rotate(Vector3.up * mouseX); 

    }

    void movePlayer()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveZ = Input.GetAxisRaw("Vertical"); 
        
        Vector3 move = playerBody.right * moveX + playerBody.forward * moveZ; 
        move.y = 0; 
        playerBody.position += move.normalized * moveSpeed * Time.deltaTime; 

        transform.position = playerBody.position + new Vector3(0, 0.5F, 0);
    }
}
