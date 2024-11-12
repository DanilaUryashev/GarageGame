using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectinPickup : MonoBehaviour
{
    public GameObject texttask;
    public GameObject textOverGame;
    //проверяем полложили ли мы все обьекты в багажник если да то выводим сообщение спасибо за игру
    private HashSet<string> enteredObjects = new HashSet<string>();

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Current objects in collider: " + string.Join(", ", enteredObjects));
        enteredObjects.Add(other.gameObject.name);
        if (enteredObjects.Contains("Absorber") && enteredObjects.Contains("Suitcase") && enteredObjects.Contains("Case"))
        {
            //Debug.Log("Все три объекта вошли в коллайдер.");
            texttask.SetActive(false);
            textOverGame.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enteredObjects.Remove(other.gameObject.name);
    }

}

    