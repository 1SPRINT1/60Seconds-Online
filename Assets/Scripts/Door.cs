using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Inventory inventory;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerStay(Collider other)
    {
        inventory.buttonActive = true;
        if (inventory.activator == true)
        {
            for (int i = 0; i < inventory.isFull.Length; i++)
            {
                inventory.isFull[i] = false;
            }
            GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("ItemImage");

            foreach (GameObject obj in objectsToDelete)
            {
                Destroy(obj);
            }
            inventory.activator = false;
            inventory.buttonActive = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inventory.buttonActive = false;
    }
}
