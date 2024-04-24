using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class IsMine : MonoBehaviour
{
   [SerializeField] private ThirdPersonController _controller;
   [SerializeField] private Inventory _inventory;
   [SerializeField] private GameObject _CameraController;
   [SerializeField] private PhotonView _photonView;

   private void Start()
   {
      if (_photonView.IsMine)
      {
         _controller.enabled = true;
         _inventory.enabled = true;
         _CameraController.SetActive(true);
         gameObject.SetActive(true);
      }
      else
      {
         _controller.enabled = false;
         _inventory.enabled = false;
         _CameraController.SetActive(false);
         gameObject.SetActive(false); 
      }
   }
}
