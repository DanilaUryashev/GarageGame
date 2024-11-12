using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    [Header("Камера игрока")]
    public Camera playerCamera;
    [Header("Дистанция подъема")]
    public float pickupDistance = 2f;
    private GameObject currentItem;
    private bool isItemHeld = false;
    private float itemHoldDistance = 1f;
    public GameObject ChekingDot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isItemHeld)
            {
                TryPickupItem();
            }
            else
            {
                DropItem();
            }
        }
        ShowCheckingDot();

        if (isItemHeld && currentItem != null)
        {
            MoveItemToFixedPosition();
        }
    }

    void TryPickupItem()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("PickupItems"))
            {
                currentItem = hit.collider.gameObject;
                currentItem.GetComponent<Collider>().enabled = false;
                currentItem.GetComponent<Renderer>().enabled = true;
                ChekingDot.SetActive(true);

                Rigidbody rb = currentItem.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                currentItem.transform.SetParent(playerCamera.transform);
                isItemHeld = true;

                ChekingDot.SetActive(false);
            }
        }
    }

    void MoveItemToFixedPosition()
    {
        currentItem.transform.localPosition = new Vector3(0, 0, itemHoldDistance);
    }

    void DropItem()
    {
        if (currentItem != null)
        {
            currentItem.GetComponent<Collider>().enabled = true;
            currentItem.GetComponent<Renderer>().enabled = true;

            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            currentItem.transform.SetParent(null);
            currentItem = null;
            isItemHeld = false;
            ChekingDot.SetActive(false);
        }
    }

    void ShowCheckingDot()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("PickupItems"))
            {
                ChekingDot.SetActive(true);
            }
            else
            {
                ChekingDot.SetActive(false);
            }
        }
        else
        {
            ChekingDot.SetActive(false);
        }
    }
}
