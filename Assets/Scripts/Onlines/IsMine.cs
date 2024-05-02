using Photon.Pun;
using UnityEngine;

public class IsMine : MonoBehaviour
{
   [SerializeField] private ThirdPersonController _controller;
   [SerializeField] private Inventory _inventory;
   [SerializeField] private GameObject _Camera;
   [SerializeField] private CameraController _cameraController;
   [SerializeField] private PhotonView _photonView;

   private void Start()
   {
      if (_photonView.IsMine)
      {
         _controller.enabled = true;
         _inventory.enabled = true;
         _Camera.SetActive(true);
         _cameraController.enabled = true;
         gameObject.SetActive(true);
      }
      else
      {
         _cameraController.enabled = false;
            _controller.enabled = false;
      }
   }
}
