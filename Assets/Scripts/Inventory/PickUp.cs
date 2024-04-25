using Photon.Pun;
using UnityEngine;

public class PickUp : MonoBehaviourPunCallbacks 
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject slotButton;
    [SerializeField] private string itemSave;
    private int isItem;
    private bool PlayerEnter;
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        slotButton = GameObject.FindGameObjectWithTag("SlotButton").GetComponent<GameObject>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.buttonActive = true;
            if (inventory.activator == true)
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {

                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        isItem = 1;
                        PlayerPrefs.SetInt(itemSave, isItem);
                        Instantiate(slotButton, inventory.slots[i].transform);
                        inventory.buttonActive = false;
                        inventory.activator = false;
                        photonView.RequestOwnership();
                        PhotonNetwork.Destroy(photonView);


                        break;
                    }
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inventory.buttonActive = false;
        inventory.activator = false;
    }
}
