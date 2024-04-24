using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    [HideInInspector] public bool buttonActive;

    [SerializeField] private GameObject button;
    [HideInInspector] public bool activator = false;
    private void Update()
    {
        Debug.Log(activator);
        button.SetActive(buttonActive);
    }
    public void OnClick()
    {
        activator = true;
    }
}
